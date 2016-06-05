using System;
using System.Collections.Generic;

namespace orez.env {
	class oParams {

		/// <summary>
		/// Indicates mode to use for getting or setting environment variable.
		/// </summary>
		public EnvironmentVariableTarget mode = EnvironmentVariableTarget.User;
		/// <summary>
		/// This includes the subcommand, and its input arguments.
		/// </summary>
		public IList<string> args = new List<string>();
	}
}
