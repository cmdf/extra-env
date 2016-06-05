using System;
using System.Collections.Generic;

namespace orez.env {
	class oParams {

		public EnvironmentVariableTarget mode = EnvironmentVariableTarget.User;
		public IList<string> args = new List<string>();
	}
}
