using System;
using System.Collections.Generic;

namespace App {
	class Program {

		// types
		/// <summary>
		/// Defines a command function that takes input parameters,
		/// and performs the necessary action.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private delegate void Fn(Params p);


		// static data
		/// <summary>
		/// Command map that associates command name with function.
		/// </summary>
		private static IDictionary<string, Fn> Cmd = new Dictionary<string, Fn> {
			[""] = new Fn(List), ["get"] = new Fn(Get), ["set"] = new Fn(Set), ["delete"] = new Fn(Delete),
			["has"] = new Fn(Has), ["add"] = new Fn(Add), ["remove"] = new Fn(Remove)
		};


		// static methods
		/// <summary>
		/// Jai Bapuji ki!
		/// </summary>
		/// <param name="args">Input parameters.</param>
		static void Main(string[] args) {
			var p = GetOpt(args);
			var key = (p.args.Length == 0 ? "" : p.args[0]).ToLower();
			key = Cmd.ContainsKey(key) ? key : "";
			try { Cmd[key](p); }
			catch(Exception e) { Console.Error.WriteLine("err: "+e.Message.ToLower()); }
		}

		/// <summary>
		/// List all environment variables.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private static void List(Params p) {
			var env = Environment.GetEnvironmentVariables(p.mode);
      foreach(var k in env.Keys)
				Console.WriteLine(k+"="+env[k]);
		}
		/// <summary>
		/// Get environment variable's value.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private static void Get(Params p) {
			var key = p.args.Length > 1 ? p.args[1] : "";
			var val = Environment.GetEnvironmentVariable(key, p.mode);
			if(val != null) Console.WriteLine(val);
		}
		/// <summary>
		/// Set environment variable's value.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private static void Set(Params p) {
			if(p.args.Length < 2) return;
			string key = p.args[1], val = p.args.Length > 2 ? p.args[2] : "";
			Environment.SetEnvironmentVariable(key, val, p.mode);
		}
		/// <summary>
		/// Delete environment variable.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private static void Delete(Params p) {
			if(p.args.Length > 1) Environment.SetEnvironmentVariable(p.args[1], null, p.mode);
		}
		/// <summary>
		/// Tells whether a sub-value is in environment variable.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private static void Has(Params p) {
			string key = p.args.Length > 1 ? p.args[1] : "", sub = p.args.Length > 2 ? p.args[2] : "";
			var val = Environment.GetEnvironmentVariable(key, p.mode);
			Console.WriteLine(val != null ? (Array.IndexOf(val.Split(';'), sub) >= 0 ? 1 : 0) : 0);
		}
		/// <summary>
		/// Add a sub-value to an environment variable.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private static void Add(Params p) {
			if(p.args.Length < 2) return;
			string key = p.args[1], sub = p.args.Length > 2 ? p.args[2] : "";
			var val = Environment.GetEnvironmentVariable(key, p.mode);
			var arr = val == null || val == "" ? new string[0] : val.Split(';');
			var lst = new List<string>(arr);
      if(!lst.Contains(sub)) lst.Add(sub);
			val = string.Join(";", lst);
			Environment.SetEnvironmentVariable(key, val, p.mode);
		}
		/// <summary>
		/// Remove a sub-value from an environment variable.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private static void Remove(Params p) {
			if(p.args.Length < 2) return;
			string key = p.args[1], sub = p.args.Length > 2 ? p.args[2] : "";
			var val = Environment.GetEnvironmentVariable(key, p.mode);
			var arr = val == null || val == "" ? new string[0] : val.Split(';');
			var lst = new List<string>(arr);
			lst.Remove(sub);
			val = string.Join(";", lst);
			Environment.SetEnvironmentVariable(key, val, p.mode);
		}

		/// <summary>
		/// Get input parameters to eenv.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		/// <returns>Input parameters.</returns>
		private static Params GetOpt(string[] args) {
			var p = new Params();
			for(var i = 0; i < args.Length; i++) {
				switch(args[i]) {
					case "--machine":
					case "-m":
						p.mode = EnvironmentVariableTarget.Machine;
						break;
					default:
						p.args = new string[args.Length - i];
						Array.Copy(args, i, p.args, 0, p.args.Length);
						i = args.Length;
						break;
				}
			}
			return p;
		}
	}
}
