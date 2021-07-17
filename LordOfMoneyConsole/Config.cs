using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using MyLibrary;

namespace LordOfMoneyConsole
{
    class Config
    {
        private ConfigSerialize _cfgSerialize = new ConfigSerialize
        {
            Type = "Serialize",
            Path = "./data.dat",
            Active = true
        };

        private ConfigSQL _cfgSql = new ConfigSQL
        {
            Type = "SQL",
            Path = "./data.db",
            Driver = "SQLLite",
            Active = false
        };

        public ConfigSerialize ExternalStorageMain
        {
            get => _cfgSerialize;
        }
        public ConfigSQL ExternalStorageBackup
        {
            get => _cfgSql;
        }

        public void Init()
        {
            /*
             @DeMernin здесь доложна быть десерилизация config.ini
             вызывать этот метод нужно только когда файл config.ini не создавался вновь
             дальше по результатам десерилизация config.ini должен создаваться объекты которые умеют работать
             с тем или иным внешним хранилищем
             иерархия этих объектов должна быть реализована на основе паттерна проектирования Репозиторий (Repository) - погугли             
             */
        }

        public void CreateOrOpen()
        {
            try
            {
                /*
                @DeMernin переписать:
                если config.ini существует, он не должен переписываться
                */

                StreamWriter sww = new StreamWriter("config.ini");//Создание файла config.ini
                                
                string jsonString = JsonSerializer.Serialize(this);
                sww.Write(jsonString);
                sww.Flush();
                sww.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found (in {this.ToString()}).");
                Library.GetTechHelp();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found (in {this.ToString()}).");
                Library.GetTechHelp();
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid (in {this.ToString()}).");
                Library.GetTechHelp();
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length (in {this.ToString()}).");
                Library.GetTechHelp();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file (in {this.ToString()}).");
                Library.GetTechHelp();
            }
            catch (IOException e) when ((System.Runtime.InteropServices.Marshal.GetHRForException(e) & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation (in {this.ToString()}).");
                Library.GetTechHelp();
            }
            catch (IOException e) when ((System.Runtime.InteropServices.Marshal.GetHRForException(e) & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists (in {this.ToString()}).");
                Library.GetTechHelp();
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred (in {this.ToString()}):\nError code: " +
                                  $"{System.Runtime.InteropServices.Marshal.GetHRForException(e) & 0x0000FFFF}\nMessage: {e.Message}");
                Library.GetTechHelp();
            }
        }
    }
}
