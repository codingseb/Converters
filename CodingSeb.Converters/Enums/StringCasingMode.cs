namespace CodingSeb.Converters
{
    /// <summary>
    /// Defines different casing modes by the <see cref="StringCaseConverter"/> 
    /// </summary>
    public enum StringCasingMode
    {
        /// <summary>
        /// Keep the string as this
        /// </summary>
        Normal,

        /// <summary>
        /// Set All letters of the string in upper case
        /// </summary>
        UPPERCASE,

        /// <summary>
        /// Set All letters of the string in lower case
        /// </summary>
        lowercase,

        /// <summary>
        /// Set the first letter of the string in upper case, keep others letters as this
        /// </summary>
        Firstletterupper,

        /// <summary>
        /// Set the first letter of the string in lower case, keep others letters as this
        /// </summary>
        firstLetterLower,

        /// <summary>
        /// Set The first letter of each word in upper case
        /// </summary>
        FirstLetterOfEachWordUpper,

        /// <summary>
        /// Set The first letter of each word in lower case
        /// </summary>
        firstletterofeachwordlower,
    }
}
