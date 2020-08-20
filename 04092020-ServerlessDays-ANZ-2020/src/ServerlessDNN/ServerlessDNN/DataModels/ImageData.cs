using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServerlessDNN.DataModels
{
    /// <summary>
    /// Manages information about the images
    /// </summary>
    public class ImageData
    {
        /// <summary>
        /// Fully qualified path of stored image
        /// </summary>
        public string ImagePath;

        /// <summary>
        /// It is the category the image belongs to. This is the value to predict.
        /// </summary>
        public string Label;

        /// <summary>
        /// Gets the collection images from the specified folder
        /// </summary>
        /// <param name="imageFolder"></param>
        /// <returns></returns>
        public static IEnumerable<ImageData> ReadFromFolder(string imageFolder)
        {
            return Directory
                .GetFiles(imageFolder, "*", SearchOption.AllDirectories)
                .Where(filepath => Path.GetExtension(filepath) == ".jpg" || Path.GetExtension(filepath) == ".png")
                .Select(filePath => new ImageData {ImagePath = filePath, Label = Path.GetFileName(filePath)});
        }
    }
}
