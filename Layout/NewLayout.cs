﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Management;
using System.Diagnostics;




namespace Layout
{
    public partial class NewLayout : Form
    {
        public NewLayout()
        {
            InitializeComponent();

            this.listBox1.DragDrop += new DragEventHandler(this.ListBox1_DragDrop);
            this.listBox1.DragEnter += new DragEventHandler(this.ListBox1_DragEnter);
        }

        private void CaptureStateButton_Click(object sender, EventArgs e)
        {
            /*
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine($"Process: {process.ProcessName}, Title: {process.MainWindowTitle}");
                }
            }
            */

            Console.WriteLine("test2");

            CaptureState captureState = new CaptureState();
            captureState.Show();

            

            List<string> list = captureState.GetApplications();

            foreach (string item in list)
            {
                this.listBox1.Items.Add(item);
            }

        }

        private void SelectFilesButton_Click(object sender, EventArgs e)
        {
            string fileName = "";

            System.IO.Stream myStream;

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Multiselect = true;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Title = "Select files to be opened";
                openFileDialog1.InitialDirectory = @"C:\";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //for (int i = 0; i < openFileDialog1.)
                    fileName = openFileDialog1.FileName;

                    foreach (string file in openFileDialog1.FileNames)
                    {
                        try
                        {
                            if ((myStream = openFileDialog1.OpenFile()) != null)
                            {
                                using (myStream)
                                {
                                    this.listBox1.Items.Add(file);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Could not read file. " + ex.Message);
                        }
                    }
                }
                else
                {
                    return;
                }

                //this.listBox1.Items.Add(fileName);

                
            }
        }

        private void SaveLayoutButton_Click(object sender, EventArgs e)
        {
            string input = this.layoutNameInput.Text;

            if (input.Trim() == "")
            {
                Console.WriteLine("Invalid Name.");
                return;
            }

            List<string> apps = new List<string>();

            for (int i = 0; i < this.listBox1.Items.Count; i++)
            {
                apps.Add(this.listBox1.Items[i].ToString());
            }


            LayoutPreset newPreset = new LayoutPreset(input, apps);
            SaveSystem.SavePreset(newPreset, true, null);



            this.Hide();
        }

        private void selectAppsButton_Click(object sender, EventArgs e)
        {

            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            foreach (ManagementObject mo in mos.Get())
            {
                Console.WriteLine(mo["Name"]);
            }



        }

        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            for (int i = 0; i < s.Length; i++)
            {
                FileInfo fileProps = new FileInfo(s[i]);

                string fileName = fileProps.FullName;

                this.listBox1.Items.Add(fileName);
            }
        }
    }
}