using System.IO;
using EasyMirror.Properties;

namespace EasyMirror {
	public interface IOperation {
		void Execute();
	}

	struct CopyOperation : IOperation {
		public FileInfo MasterFile {
			get { return _masterFile; }
		}
		public FileInfo MirrorFile {
			get { return _mirrorFile; }
		}
		private readonly FileInfo _masterFile;
		private readonly FileInfo _mirrorFile;

		public CopyOperation(FileInfo masterFile, FileInfo mirrorFile) {
			_masterFile = masterFile;
			_mirrorFile = mirrorFile;
		}

		public void Execute() {
			File.Copy(MasterFile.FullName, MirrorFile.FullName);
		}

		public override string ToString() {
			return Resources.NEW_FILE + MasterFile.FullName;
		}
	}

	struct DeleteOperation : IOperation {
		public FileInfo MirrorFile {
			get { return _mirrorFile; }
		}
		private readonly FileInfo _mirrorFile;

		public DeleteOperation(FileInfo mirrorFile) {
			_mirrorFile = mirrorFile;
		}

		public void Execute() {
			File.Delete(MirrorFile.FullName);
		}

		public override string ToString() {
			return Resources.DELETE_FILE + MirrorFile.FullName;
		}
	}

	struct OverwriteOperation : IOperation {
		public FileInfo MasterFile {
			get { return _masterFile; }
		}
		public FileInfo MirrorFile {
			get { return _mirrorFile; }
		}
		private readonly FileInfo _masterFile;
		private readonly FileInfo _mirrorFile;

		public OverwriteOperation(FileInfo masterFile, FileInfo mirrorFile) {
			_masterFile = masterFile;
			_mirrorFile = mirrorFile;
		}

		public void Execute() {
			File.Copy(MasterFile.FullName, MirrorFile.FullName, true);
		}

		public override string ToString() {
			return Resources.OVERWRITE_FILE + MasterFile.FullName;
		}
	}

	struct NewDirectoryOperation : IOperation {
		public DirectoryInfo MasterDir {
			get { return _masterDir; }
		}
		public DirectoryInfo MirrorDir {
			get { return _mirrorDir; }
		}
		private readonly DirectoryInfo _masterDir;
		private readonly DirectoryInfo _mirrorDir;

		public NewDirectoryOperation(DirectoryInfo masterDir, DirectoryInfo mirrorDir) {
			_masterDir = masterDir;
			_mirrorDir = mirrorDir;
		}

		public void Execute() {
			Directory.CreateDirectory(MirrorDir.FullName);
		}

		public override string ToString() {
			return Resources.NEW_DIRECTORY + MasterDir.FullName;
		}
	}

	struct DeleteDirectoryOperation : IOperation {
		public DirectoryInfo MirrorDir {
			get { return _mirrorDir; }
		}
		private readonly DirectoryInfo _mirrorDir;

		public DeleteDirectoryOperation(DirectoryInfo mirrorDir) {
			_mirrorDir = mirrorDir;
		}

		public void Execute() {
			Directory.Delete(MirrorDir.FullName);
		}

		public override string ToString() {
			return Resources.DELETE_DIRECTORY + MirrorDir.FullName;
		}
	}
}
