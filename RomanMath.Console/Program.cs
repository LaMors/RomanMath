﻿using System;
using RomanMath.Impl;

namespace RomanMath.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in RomanMath.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var result = Service.Evaluate(System.Console.ReadLine());

            System.Console.WriteLine(result);

			System.Console.ReadKey();
		}
	}
}
