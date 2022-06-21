// Author: Laura Zhan
// File Name: Instructions.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the instructions page

using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Animation2D;
using Helper;
using Microsoft.Xna.Framework.Content;

namespace EscapeRoom
{
    public class Instructions : SubMenu
    {
        private static StreamReader inFile = null;

        private static string fileName = "instructions.txt";

        public Instructions(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string titleTxt) : base(Content, spriteBatch, screenWidth, screenHeight, titleTxt)
        {
        }

        //Pre: none
        //Post: none
        //Desc: loads instructions page
        public override void LoadContent()
        {
            base.LoadContent();
            
            LoadInstructions();
        }

        private void LoadInstructions()
        {
            string line;
            int counter = 0;
            int lineGap = 20;

            try
            {
                //Stores the file's content
                inFile = File.OpenText(fileName);

                //Perform the following actions until it reaches the end of the file
                while (!inFile.EndOfStream)
                {
                    //Adds the word as an element to a list
                    line = inFile.ReadLine();
                    displayables.Add(new Clickable(50, 100 + counter * lineGap, line, Game1.font, Color.White));

                    counter++;
                }
            }
            catch (FileNotFoundException fnf)
            {
                //outputs file not found error
                Console.WriteLine("ERROR: " + fnf.Message);
            }
            catch (FormatException fe)
            {
                //outputs format exception error
                Console.WriteLine("ERROR: " + fe.Message);
            }
            catch (Exception e)
            {
                //outputs general error
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                //Close the file if it's not empty
                if (inFile != null)
                {
                    inFile.Close();
                }
            }
        }
    }
}
