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

using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ProtonVPN.Core.Storage;
using ProtonVPN.Settings.Migrations.v1_8_0;

namespace ProtonVPN.App.Test.Core.Settings.Migrations.v1_8_0
{
    [TestClass]
    public class AppSettingsMigrationTest
    {
        private ISettingsStorage _storage;

        [TestInitialize]
        public void TestInitialize()
        {
            _storage = Substitute.For<ISettingsStorage>();
        }

        [TestMethod]
        public void ToVersion_ShouldBe_1_8_0()
        {
            // Arrange
            var migration = new AppSettingsMigration(_storage);
            // Act
            var result = migration.ToVersion;
            // Assert
            result.Should().Be(new Version(1, 8, 0));
        }

        [TestMethod]
        public void Apply_Should_SwitchOff_SplitTunnel_WhenKillSwitch_IsOn()
        {
            // Arrange
            _storage.Get<bool>("KillSwitch").Returns(true);
            _storage.Get<bool>("SplitTunnelingEnabled").Returns(true);
            var migration = new AppSettingsMigration(_storage);
            // Act
            migration.Apply();
            // Assert
            _storage.Received().Set("SplitTunnelingEnabled", false);
        }

        [TestMethod]
        public void Apply_Should_NotSwitchOff_SplitTunnel_WhenKillSwitch_IsOff()
        {
            // Arrange
            _storage.Get<bool>("KillSwitch").Returns(false);
            _storage.Get<bool>("SplitTunnelingEnabled").Returns(true);
            var migration = new AppSettingsMigration(_storage);
            // Act
            migration.Apply();
            // Assert
            _storage.DidNotReceive().Set("SplitTunnelingEnabled", Arg.Any<bool>());
        }
    }
}
