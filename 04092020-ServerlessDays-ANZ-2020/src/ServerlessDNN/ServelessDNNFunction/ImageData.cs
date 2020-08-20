using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServelessDNNFunction.DataModels
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
        /// <param name="useFolderNameAsLabel">Uses folder name as label instead of file name</param>
        /// <returns></returns>
        public static IEnumerable<ImageData> ReadFromFolder(string imageFolder, bool useFolderNameAsLabel = false)
        {
            var files = Directory.GetFiles(imageFolder, "*", searchOption: SearchOption.AllDirectories);

            foreach (var file in files)
            {
                if ((Path.GetExtension(file) != ".jpg") && (Path.GetExtension(file) != ".png"))
                    continue;

                var label = Path.GetFileName(file);

                if (useFolderNameAsLabel)
                    label = Directory.GetParent(file).Name;
                else
                {
                    for (int index = 0; index < label.Length; index++)
                    {
                        if (!char.IsLetter(label[index]))
                        {
                            label = label.Substring(0, index);
                            break;
                        }
                    }
                }

                yield return new ImageData()
                {
                    ImagePath = file,
                    Label = label
                };
            }
        }
    }
}
