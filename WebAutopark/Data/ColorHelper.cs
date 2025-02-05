using System.Drawing;

namespace WebAutopark.Data
{
    public class ColorHelper
    {
        public static string GetColorNameFromHex(string hexColor)
        {
            // Convert HEX to RGB
            Color inputColor = ColorTranslator.FromHtml(hexColor);

            // Check if it's a known color
            if (inputColor.IsKnownColor)
            {
                return inputColor.Name; // Returns a known color name (e.g., "Red", "Blue")
            }

            return "Unknown"; // If not a known color
        }

        public static string ConvertColorNameToHex(string colorName)
        {
            try
            {
                Color color = Color.FromName(colorName);

                // Ensure the color is valid (not empty)
                if (color.ToArgb() == 0)
                    return "Invalid Color Name";

                return $"#{color.R:X2}{color.G:X2}{color.B:X2}"; // Convert to HEX
            }
            catch
            {
                return "Invalid Color Name";
            }
        }
    }
}
