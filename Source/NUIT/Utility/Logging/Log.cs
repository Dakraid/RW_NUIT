// --------------------------------------------------------------------------------------------------------------------
// Filename : Log.cs
// Project: NUIT / NUIT
// Author : Kristian Schlikow (kristian@schlikow.de)
// Created On : 12.07.2021 18:48
// Last Modified On : 12.07.2021 19:27
// Copyrights : Copyright (c) Kristian Schlikow 2021-2021, All Rights Reserved
// License: License is provided as described within the LICENSE file shipped with the project
// If present, the license takes precedence over the individual notice within this file
// --------------------------------------------------------------------------------------------------------------------

namespace NUIT.Utility.Logging
{
    using System;

    using Components;

    using Verse;

    internal static class Log
    {
        private const string NamePrefix = "NUIT";

        public static void Write(string message, LogLevel severity, bool skipMessage = false)
        {
            if (severity < NuitMod.Settings.LogSeverity || skipMessage)
                return;

            if (string.IsNullOrWhiteSpace(message))
                return;

            var formattedMessage = "[" + NamePrefix + "] " + message;

            switch (severity)
            {
                case LogLevel.Trace:
                    Verse.Log.Message(formattedMessage);

                    break;

                case LogLevel.Debug:
                    Verse.Log.Message(formattedMessage);

                    break;

                case LogLevel.Information:
                    Verse.Log.Message(formattedMessage);

                    break;

                case LogLevel.Warning:
                    Verse.Log.Warning(formattedMessage);

                    break;

                case LogLevel.Error:
                    Verse.Log.Error(formattedMessage);

                    break;

                case LogLevel.Critical:
                    Verse.Log.Error(formattedMessage);

                    break;

                case LogLevel.None:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(severity), severity, null);
            }
        }

        public static void Write(string format, LogLevel severity, bool skipMessage = false, params object[] args)
        {
            if (severity < NuitMod.Settings.LogSeverity || skipMessage)
                return;

            if (string.IsNullOrWhiteSpace(format) || args.NullOrEmpty())
                return;

            var formattedMessage = "[" + NamePrefix + "] " + string.Format(format, args);

            switch (severity)
            {
                case LogLevel.Trace:
                    Verse.Log.Message(formattedMessage);

                    break;

                case LogLevel.Debug:
                    Verse.Log.Message(formattedMessage);

                    break;

                case LogLevel.Information:
                    Verse.Log.Message(formattedMessage);

                    break;

                case LogLevel.Warning:
                    Verse.Log.Warning(formattedMessage);

                    break;

                case LogLevel.Error:
                    Verse.Log.Error(formattedMessage);

                    break;

                case LogLevel.Critical:
                    Verse.Log.Error(formattedMessage);

                    break;

                case LogLevel.None:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(severity), severity, null);
            }
        }
    }
}
