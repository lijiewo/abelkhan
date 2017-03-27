﻿using System;
using System.Reflection;
using System.Collections;

namespace juggle
{
    public class Imodule
    {
		public void process_event(Ichannel _ch, ArrayList _event)
		{
			current_ch = _ch;

			String func_name = (String)_event[1];

			Type type = GetType();
			MethodInfo method = type.GetMethod(func_name);

			if (method != null)
			{
				try
				{
					object[] argv = new object[1];
					if (_event.Count > 2)
					{
						argv[0] = (ArrayList)_event[2];
					}
					method.Invoke(this, argv);

					current_ch = null;
				}
				catch(Exception e)
				{
					Console.WriteLine("function name:" + func_name + " " + e.ToString());
				} 
			}
			else
			{
				Console.WriteLine("do not have a function named:" + func_name);
			}
		}

		public static Ichannel current_ch;
		public String module_name;
    }
}