using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSpec.Shell.Display
{
    /// <summary>
    /// Formats colors and style of displaying test information.
    /// </summary>
    public class ConsoleFormatter
    {
        /// <summary>
        /// Default Constructior when invoked uses default formatting
        /// </summary>
        public ConsoleFormatter()
        {
            DescriptionColor = new ColorFormatter();
            DescriptionColor.Background = ConsoleColor.Black;
            DescriptionColor.Foreground = ConsoleColor.White;

            NameColor = new ColorFormatter();
            NameColor.Background = ConsoleColor.DarkGreen;
            NameColor.Foreground = ConsoleColor.White;

            SuccessResultColor = new ColorFormatter();
            SuccessResultColor.Background = ConsoleColor.Black;
            SuccessResultColor.Foreground = ConsoleColor.Green;

            ErrorResultColor = new ColorFormatter();
            ErrorResultColor.Background = ConsoleColor.Black;
            ErrorResultColor.Foreground = ConsoleColor.Red;

            InfoColor = new ColorFormatter();
            InfoColor.Background = ConsoleColor.Black;
            InfoColor.Foreground = ConsoleColor.Gray;

            Separator = "----------------------";
        }

        /// <summary>
        /// Gets/Sets Colors for standard writeLine operation
        /// </summary>
        public ColorFormatter InfoColor { get; set; }
        /// <summary>
        /// Gets/Sets Colors for operation description
        /// </summary>
        public ColorFormatter DescriptionColor { get; set; }
        /// <summary>
        /// Gets/Sets Colors for operation name
        /// </summary>
        public ColorFormatter NameColor { get; set; }
        /// <summary>
        /// Gets/Sets Colors for result of the successful operation
        /// </summary>
        public ColorFormatter SuccessResultColor { get; set; }
        /// <summary>
        /// Gets/Sets Colors for result of the error operation
        /// </summary>
        public ColorFormatter ErrorResultColor { get; set; }
        /// <summary>
        /// Gets/Sets The separator string.
        /// </summary>
        public string Separator { get; set; }
    }
}
