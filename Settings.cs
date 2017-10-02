using System;
using System.IO;
using System.Xml;

namespace FlashAir {
  public class Settings {
    static string SettingsFile = "settings.xml";
    XmlDocument xd;

    public Settings() {
      xd = new XmlDocument();
      if(File.Exists(SettingsFile) == false) {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.NewLineHandling = NewLineHandling.Entitize;
        XmlWriter xw = XmlWriter.Create(SettingsFile, settings);
        xw.WriteStartDocument();
        xw.WriteStartElement("settings");
        xw.WriteElementString("version", "1.0");
        xw.WriteElementString("sync_path", @"D:\FlashAir");
        xw.WriteElementString("sync_auto", "true");
        xw.WriteElementString("sync_time", "10000");
        xw.WriteElementString("root_dir", "/DCIM");
        xw.WriteElementString("card_ssid", "FlashAir");
        xw.WriteEndElement();
        xw.Flush();
        xw.Close();
        }
      }

    public bool DeleteSetting(string name) {
      try {
        xd["settings"].RemoveChild(xd["settings"][name]);
        } catch(NullReferenceException) {
        return false;
        }
      return true;
      }

    public void Close() {
      xd.Save(SettingsFile);
      }

    public string this[string name] {
      get {
        xd.Load(SettingsFile);
        try {
          return xd["settings"][name].InnerText;
          } catch(NullReferenceException) {
          return null;
          }
        }
      set {
        xd.Load(SettingsFile);
        if(xd["settings"][name] != null) {
          xd["settings"][name].InnerText = value;
          } else {
          XmlElement xe = xd.CreateElement(name);
          xe.InnerText = value;
          xd["settings"].AppendChild(xe);
          }
        Close();
        }
      }

    }
  }
