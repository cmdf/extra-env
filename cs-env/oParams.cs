using System;
using System.Collections.Generic;

namespace orez.env {
	class oParams {

		/// <summary>
		/// Indicates mode to use for getting or setting environment variable.
		/// </summary>
		public EnvironmentVariableTarget mode = EnvironmentVariableTarget.User;
		public IList<string> args = new List<string>();
	}
}
