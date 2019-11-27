namespace CodingSeb.Converters
{
    /// <summary>
    /// An enum to define standard directory paths for C# apps
    /// Reproduce Environment.SpecialFolder and add some other types of path
    /// </summary>
    public enum DirectoryPath
    {
        /// <summary>
        /// To provide the full path of the directory
        /// </summary>
        AbsolutePath,

        /// <summary>
        /// To provide a path relative to the directory of the Entry Assembly
        /// </summary>
        EntryAssemblyDirectory,

        /// <summary>
        /// To provide a path relative to the directory of the Executing Assembly
        /// </summary>
        ExecutingAssemblyDirectory,

        // --------------------------------------------------------
        #region // From here reproduce The Environment.SpecialFolder enum
        // --------------------------------------------------------

        /// <summary>
        /// The file system directory that is used to store administrative tools for an individual user. The Microsoft Management Console (MMC) will save customized consoles to this directory, and it will roam with the user. Added in the .NET Framework 4.
        /// </summary>
        AdminTools,

        /// <summary>
        /// The directory that serves as a common repository for application-specific data for the current roaming user. A roaming user works on more than one computer on a network. A roaming user's profile is kept on a server on the network and is loaded onto a system when the user logs on.
        /// </summary>
        ApplicationData,

        /// <summary>
        /// The file system directory that acts as a staging area for files waiting to be written to a CD. Added in the .NET Framework 4.
        /// </summary>
        CDBurning,

        /// <summary>
        /// The file system directory that contains administrative tools for all users of the computer. Added in the .NET Framework 4.
        /// </summary>
        CommonAdminTools,

        /// <summary>
        /// The directory that serves as a common repository for application-specific data that is used by all users.
        /// </summary>
        CommonApplicationData,

        /// <summary>
        /// The file system directory that contains files and folders that appear on the desktop for all users. This special folder is valid only for Windows NT systems. Added in the .NET Framework 4.
        /// </summary>
        CommonDesktopDirectory,

        /// <summary>
        /// The file system directory that contains documents that are common to all users. This special folder is valid for Windows NT systems, Windows 95, and Windows 98 systems with Shfolder.dll installed. Added in the .NET Framework 4.
        /// </summary>
        CommonDocuments,

        /// <summary>
        /// The file system directory that serves as a repository for music files common to all users. Added in the .NET Framework 4.
        /// </summary>
        CommonMusic,

        /// <summary>
        /// This value is recognized in Windows Vista for backward compatibility, but the special folder itself is no longer used. Added in the .NET Framework 4.
        /// </summary>
        CommonOemLinks,

        /// <summary>
        /// The file system directory that serves as a repository for image files common to all users. Added in the .NET Framework 4.
        /// </summary>
        CommonPictures,

        /// <summary>
        /// <para>The directory for components that are shared across applications.</para>
        /// <para>To get the x86 common program files directory on a non-x86 system, use the ProgramFilesX86 member.</para>
        /// </summary>
        CommonProgramFiles,

        /// <summary>
        /// The Program Files folder. Added in the .NET Framework 4.
        /// </summary>
        CommonProgramFilesX86,

        /// <summary>
        /// A folder for components that are shared across applications. This special folder is valid only for Windows NT, Windows 2000, and Windows XP systems. Added in the .NET Framework 4.
        /// </summary>
        CommonPrograms,

        /// <summary>
        /// The file system directory that contains the programs and folders that appear on the Start menu for all users. This special folder is valid only for Windows NT systems. Added in the .NET Framework 4.
        /// </summary>
        CommonStartMenu,

        /// <summary>
        /// The file system directory that contains the programs that appear in the Startup folder for all users. This special folder is valid only for Windows NT systems. Added in the .NET Framework 4.
        /// </summary>
        CommonStartup,

        /// <summary>
        /// The file system directory that contains the templates that are available to all users. This special folder is valid only for Windows NT systems. Added in the .NET Framework 4.
        /// </summary>
        CommonTemplates,

        /// <summary>
        /// The file system directory that serves as a repository for video files common to all users. Added in the .NET Framework 4.
        /// </summary>
        CommonVideos,

        /// <summary>
        /// The directory that serves as a common repository for Internet cookies.
        /// </summary>
        Cookies,

        /// <summary>
        /// The logical Desktop rather than the physical file system location.
        /// </summary>
        Desktop,

        /// <summary>
        /// The directory used to physically store file objects on the desktop. Do not confuse this directory with the desktop folder itself, which is a virtual folder.
        /// </summary>
        DesktopDirectory,

        /// <summary>
        /// The directory that serves as a common repository for the user's favorite items.
        /// </summary>
        Favorites,

        /// <summary>
        /// A virtual folder that contains fonts. Added in the .NET Framework 4.
        /// </summary>
        Fonts,

        /// <summary>
        /// The directory that serves as a common repository for Internet history items.
        /// </summary>
        History,

        /// <summary>
        /// The directory that serves as a common repository for temporary Internet files.
        /// </summary>
        InternetCache,

        /// <summary>
        /// The directory that serves as a common repository for application-specific data that is used by the current, non-roaming user.
        /// </summary>
        LocalApplicationData,

        /// <summary>
        /// The file system directory that contains localized resource data. Added in the .NET Framework 4.
        /// </summary>
        LocalizedResources,

        /// <summary>
        /// The My Computer folder. When passed to the Environment.GetFolderPath method, the MyComputer enumeration member always yields the empty string ("") because no path is defined for the My Computer folder.
        /// </summary>
        MyComputer,

        /// <summary>
        /// The My Documents folder. This member is equivalent to Personal.
        /// </summary>
        MyDocuments,

        /// <summary>
        /// The My Music folder.
        /// </summary>
        MyMusic,

        /// <summary>
        /// The My Pictures folder.
        /// </summary>
        MyPictures,

        /// <summary>
        /// The file system directory that serves as a repository for videos that belong to a user. Added in the .NET Framework 4.
        /// </summary>
        MyVideos,

        /// <summary>
        /// A file system directory that contains the link objects that may exist in the My Network Places virtual folder. Added in the .NET Framework 4.
        /// </summary>
        NetworkShortcuts,

        /// <summary>
        /// The directory that serves as a common repository for documents. This member is equivalent to MyDocuments.
        /// </summary>
        Personal,

        /// <summary>
        /// The file system directory that contains the link objects that can exist in the Printers virtual folder. Added in the .NET Framework 4.
        /// </summary>
        PrinterShortcuts,

        /// <summary>
        /// <para>The program files directory.</para>
        /// <para>On a non-x86 system, passing ProgramFiles to the GetFolderPath(Environment+SpecialFolder) method returns the path for non-x86 programs. To get the x86 program files directory on a non-x86 system, use the ProgramFilesX86 member.</para>
        /// </summary>
        ProgramFiles,

        /// <summary>
        /// The x86 Program Files folder. Added in the .NET Framework 4.
        /// </summary>
        ProgramFilesX86,

        /// <summary>
        /// The directory that contains the user's program groups.
        /// </summary>
        Programs,

        /// <summary>
        /// The directory that contains the user's most recently used documents.
        /// </summary>
        Recent,

        /// <summary>
        /// The file system directory that contains resource data. Added in the .NET Framework 4.
        /// </summary>
        Resources,

        /// <summary>
        /// The directory that contains the Send To menu items.
        /// </summary>
        SendTo,

        /// <summary>
        /// The directory that contains the Start menu items.
        /// </summary>
        StartMenu,

        /// <summary>
        /// The directory that corresponds to the user's Startup program group. The system starts these programs whenever a user logs on or starts Windows.
        /// </summary>
        Startup,

        /// <summary>
        /// The System directory.
        /// </summary>
        System,

        /// <summary>
        /// The Windows System folder. Added in the .NET Framework 4.
        /// </summary>
        SystemX86,

        /// <summary>
        /// The directory that serves as a common repository for document templates.
        /// </summary>
        Templates,

        /// <summary>
        /// The user's profile folder. Applications should not create files or folders at this level; they should put their data under the locations referred to by ApplicationData. Added in the .NET Framework 4.
        /// </summary>
        UserProfile,

        /// <summary>
        /// The Windows directory or SYSROOT. This corresponds to the %windir% or %SYSTEMROOT% environment variables. Added in the .NET Framework 4.
        /// </summary>
        Windows,

        #endregion
    }
}
