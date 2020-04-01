﻿/**********************************************
* CONFIDENTIAL AND PROPRIETARY
*
* The source code and other information contained herein is the confidential and the exclusive property of
* ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
* This source code, and any other information contained herein, shall not be copied, reproduced, published,
* displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
* expressly permitted under such license agreement.
*
* Copyright ZIH Corp. 2011
*
* ALL RIGHTS RESERVED
***********************************************
File: SampleCodeGraphics.cs
Description: Example code showing how to print graphics and text to a card.
$Revision: 1 $
$Date: 2011/08/10 $
*******************************************************************************/

using System;
using System.Text;
using System.Threading;

namespace BSAF
{
    class SampleCodeGraphics
    {
        #region Declarations

        // Constants ----------------------------------------------------------------------------------------

        const int FONT_BOLD = 0x01;
        const int FONT_ITALIC = 0x02;
        const int FONT_UNDERLINE = 0x04;
        const int FONT_STRIKETHRU = 0x08;

        #endregion

         // Private Variables --------------------------------------------------------------------------------
        #region Declarations


        
        #endregion

        #region Constructor 

        // Class Initialization
        //     gets the ZBRGraphics.dll version -------------------------------------------------------------

        public SampleCodeGraphics()
        {
        }

        #endregion

        #region Get SDL DLL Version

        // Gets the DLL version for the SDK -----------------------------------------------------------------

        public string GetSDKVersion()
        {
            ZBRGraphics graphics = null; 

            string version = "";

            try
            {
                graphics = new ZBRGraphics();

                version =  graphics.GetGraphicsSDKVersion(); 
            }
            catch (Exception ex)
            {
                version = ex.ToString();
            }
            finally
            {
                graphics = null;
            }
            return version;
        }

        #endregion


        #region Printing Facade


        /**************************************************************************************************
        * Function Name: PrintSingleSideJob
        * 
        * Purpose: Performs the necessary tasks to define a single-sided print job, and send the job
        *           to the selected printer.
        * 
        * Parameters: drvName = string containing name of selected printer
        *             DrawObject = SampleCodeDrawConfiguration object with details about the printed card data
        *             msg = string containing an error message if an error occurs.  
        *                 
        * Returns: None 
        * 
        * History:
        * Date             Who             Comment
        * 08/01/2011       ACT             Function creation.
        ***************************************************************************************************/
        public void PrintFrontSideOnly(string drvName, SampleCodeDrawConfiguration drawObject, out string msg)
        {
            int errValue;    // value of 0 indicates no errors
            ZBRGraphics graphics = new ZBRGraphics();
            IntPtr hDC = IntPtr.Zero;
            msg = string.Empty;
            try
            {
                if (graphics.InitGraphics(graphics.AsciiEncoder.GetBytes(drvName), out errValue) == 0)
                {
                    msg = "Printing InitGraphics Error: " + errValue.ToString();
                    return;
                }

                //// Places an Image based on the background selected
                if (drawObject.cardImage != null)
                {
                    if (graphics.DrawImage(drawObject.cardImage, drawObject.cardImageLocation.X,
                        drawObject.cardImageLocation.Y, drawObject.cardImageLocation.Width, drawObject.cardImageLocation.Height,
                        out errValue) == 0)
                    {
                        msg = "Printing DrawImage Error: " + errValue.ToString();
                        return;
                    }
                }
                
                if (graphics.PrintGraphics(out errValue) == 0)
                {
                    msg = "Printing PrintGraphics Error: " + errValue.ToString();
                    return;
                }
            }
            catch (Exception ex)
            {
                msg += "PrintFrontSideOnly threw exception " + ex.ToString();
            }
            finally
            {
                // Starts the printing process and releases the Graphics Buffer
                if (graphics.CloseGraphics(out errValue) == 0)
                {
                    msg = "Printing CloseGraphics Error: " + errValue.ToString();
                }
            }
        }
        #endregion //Printing Facade
    }
}
