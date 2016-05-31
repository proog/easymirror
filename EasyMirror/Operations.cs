using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EasyMirror {
	class Operations : List<IOperation> {
		public int CopyOperations;
		public int NewDirOperations;
		public int OverwriteOperations;
		public int DeleteOperations;
		public int DeleteDirOperations;
		private List<DirectoryInfo> _BadPaths   = new List<DirectoryInfo>();
		private List<IOperation> _BadOperations = new List<IOperation>();

		public List<DirectoryInfo> BadPaths   { get { return _BadPaths;      } }
		public List<IOperation> BadOperations { get { return _BadOperations; } }
	}
}
