﻿/*
 * Copyright (c) 2022 Proton Technologies AG
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

using System.Threading.Tasks;

namespace ProtonVPN.Update.Updates
{
    /// <summary>
    /// Interface to the app update state plus the app update related operations.
    /// </summary>
    internal interface IAppUpdate : IBaseAppUpdateState
    {
        Task<IAppUpdate> Latest(bool earlyAccess);

        IAppUpdate CachedLatest(bool earlyAccess);

        Task<IAppUpdate> Downloaded();

        Task<IAppUpdate> Validated();

        Task<IAppUpdate> Started(bool auto);
    }
}
