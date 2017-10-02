using System.Net;
using System.Collections.Generic;
using System.IO;
using System;

namespace FlashAir {
  class Controller {

    WebClient wc;
    Settings st;

    string RootDir;
    string SincroPath;

    string sp = Path.DirectorySeparatorChar.ToString();

    public Controller() {
      wc = new WebClient();
      st = new Settings();

      RootDir = st["root_dir"];
      SincroPath = st["sync_path"];
      }

        /**
        <summary>Scans the elements of the card and returns a list of folders and files</summary>
        <returns>Object ScanResult</returns>*/
        public ScanResult Scan() {
      if(CheckConditions(null)) {

        List<ItemData> files = new List<ItemData>();
        List<ItemData> folders = new List<ItemData>();

        int checkedFolders = 0;
        int size = 0;

        string[] itemsList = GetItems(RootDir);
        do {
          if(checkedFolders == 0) {
            foreach(string lst in itemsList) {
              ItemData fd = new ItemData(lst);
              if(fd.size == "0") {
                folders.Add(fd);
                } else {
                files.Add(fd);
                size += int.Parse(fd.size);
                }
              }
            checkedFolders = 1;
            } else {
            for(int c = 0; folders.Count > c; c++) {
              itemsList = GetItems(folders[c].folder + "/" + folders[c].name);
              foreach(string lst in itemsList) {
                ItemData fd = new ItemData(lst);
                if(fd.size == "0") {
                  folders.Add(fd);
                  } else {
                  files.Add(fd);
                  size += int.Parse(fd.size);
                  }
                }
              checkedFolders++;
              }
            }
          } while(folders.Count > checkedFolders);

        //Guarda un log de los datos en log.html y devuelve el resultado
        if(folders.Count > 0 || files.Count > 0) {
          string toLog = "<h3>Directorios</h3>";
          foreach(ItemData id in folders) {
            toLog += id.folder + "/" + id.name + "<br/>";
            }
          toLog += "<h3>Archivos</h3>";
          foreach(ItemData id in files) {
            toLog += id.name + " (" + id.folder + ")<br/>";
            }
          File.WriteAllText(SincroPath + @"\scan.html", toLog);

          return new ScanResult(folders, files, size);
          }
        }
      return null;
      }

        /**
        <summary>Copies the items from the card to the specified folder</summary>
        <returns>True, if success. False if there was an error, especially of remaining space.</returns>*/
        public bool Sincronize() {
      ScanResult sr = Scan();

      if(sr!=null && CheckConditions(sr.size)) {
        string logWrite = "<h3>Directorios Creados</h3>";
        foreach(ItemData id in sr.folders) {
          if(Directory.Exists(SincroPath + id.folderEs + sp + id.name) == false) {
            Directory.CreateDirectory(SincroPath + id.folderEs + sp + id.name);
            logWrite += "Creado: " + SincroPath + id.folderEs + sp + id.name + "<br/>";
            }
          }

        logWrite += "<h3>Archivos Descargados</h3>";
        foreach(ItemData id in sr.files) {
          if(File.Exists(SincroPath + id.folderEs + sp + id.name) == false) {
            try {
              wc.DownloadFile("http://flashair" + id.folder + "/" + id.name, SincroPath + id.folderEs + sp + id.name);
              logWrite += id.folderEs + sp + id.name + "<br/>";
              } catch(WebException e) {
              logWrite += "<b>Fallo: </b>" + id.folder + sp + id.name + " <b>(" + e.StackTrace + ")</b><br/>";
              }
            }
          }
        //Escribe el log en update.html
        File.WriteAllText(SincroPath + @"\update.html", logWrite);
        } else {
        return false;
        }
      return true;
      }

    private bool CheckConditions(int? size) {

      try {
        if(wc.DownloadString("http://flashair/command.cgi?op=100&DIR=" + RootDir) == "") {
          return false;
          }
        } catch(WebException) {
        return false;
        }

      if(size != null && new DriveInfo("D:").TotalFreeSpace <= size) {
        return false;
        }

      if(Directory.Exists(SincroPath)) {
        } else {
        Directory.CreateDirectory(SincroPath);
        }

      return true;
}

    public string[] GetItems(string root) {
      return wc.DownloadString("http://flashair/command.cgi?op=100&DIR=" + root).Replace("WLANSD_FILELIST", "").Trim().Split('\n');
      }

    public static bool Available() {
      try {
        WebClient wc = new WebClient();
        return wc.DownloadString("http://flashair/command.cgi?op=100&DIR=/").Contains("WLANSD_FILELIST");
        } catch(WebException) {
        return false;
        }
      }

    public class ItemData {
      public ItemData(string source) {
        string[] data = source.Split(',');
        folder = data[0];
        folderEs = data[0].Replace('/', Path.DirectorySeparatorChar);
        name = data[1];
        size = data[2];
        atribute = data[3];
        date = data[4];
        time = data[5];
        }

      public string folder { get; }
      public string folderEs { get; }
      public string name { get; }
      public string size { get; }
      public string atribute { get; }
      public string date { get; }
      public string time { get; }
      }

    public class ScanResult {
       public ScanResult(List<ItemData> folders, List<ItemData> files, int size) {
        this.folders = folders;
        this.files = files;
        this.size = size;
        }

      public List<ItemData> folders { get; }
      public List<ItemData> files { get; }
      public int size { get; }
      }
    }
  }
