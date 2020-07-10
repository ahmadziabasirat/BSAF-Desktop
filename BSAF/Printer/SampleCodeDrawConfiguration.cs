/**********************************************
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
File: SampleCodeDrawConfiguration.cs
Description: Example code used to store configuration for the data to be passed to the Graphics
$Revision: 1 $
$Date: 2011/08/15 $
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BSAF.Printer
{
    public class SampleCodeDrawConfiguration
    {
        public byte[] cardImage { get; set; } 
        public Rectangle cardImageLocation { get; set; }

 
    }
}
