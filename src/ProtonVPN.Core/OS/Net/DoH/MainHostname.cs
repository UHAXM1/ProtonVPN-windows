﻿/*
 * Copyright (c) 2020 Proton Technologies AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Text;
using Albireo.Base32;
using ProtonVPN.Common.Configuration;

namespace ProtonVPN.Core.OS.Net.DoH
{
    public class MainHostname
    {
        private readonly Config _config;

        private string _hostFormat = "d{0}.protonpro.xyz";

        public MainHostname(Config config)
        {
            _config = config;
        }

        public string Value()
        {
            return string.Format(_hostFormat, GetBase32Host());
        }

        private string GetBase32Host()
        {
            var apiUri = new Uri(_config.Urls.ApiUrl);
            return Base32.Encode(Encoding.UTF8.GetBytes(apiUri.Host)).TrimEnd('=');
        }
    }
}