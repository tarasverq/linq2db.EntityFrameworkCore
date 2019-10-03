﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;

namespace LinqToDB.EntityFrameworkCore.Tests
{
	public static class TestLoggerExtensions
	{
		/// <summary>
		/// Adds a console logger named 'Console' to the factory.
		/// </summary>
		/// <param name="builder">The <see cref="ILoggingBuilder"/> to use.</param>
		public static ILoggingBuilder AddTestLogger(this ILoggingBuilder builder)
		{
			builder.AddConfiguration();

			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, TestLoggerProvider>());
			LoggerProviderOptions.RegisterProviderOptions<ConsoleLoggerOptions, TestLoggerProvider>(builder.Services);
			return builder;
		}

		/// <summary>
		/// Adds a console logger named 'Console' to the factory.
		/// </summary>
		/// <param name="builder">The <see cref="ILoggingBuilder"/> to use.</param>
		/// <param name="configure">A delegate to configure the <see cref="ConsoleLogger"/>.</param>
		public static ILoggingBuilder AddTestLogger(this ILoggingBuilder builder, Action<ConsoleLoggerOptions> configure)
		{
			if (configure == null)
			{
				throw new ArgumentNullException(nameof(configure));
			}

			builder.AddTestLogger();
			builder.Services.Configure(configure);

			return builder;
		}
	}}
