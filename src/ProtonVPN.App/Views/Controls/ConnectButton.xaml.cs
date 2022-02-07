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

using System.Windows;
using System.Windows.Input;

namespace ProtonVPN.Views.Controls
{
    public partial class ConnectButton
    {
        public static DependencyProperty ClickCommandProperty
            = DependencyProperty.Register(
                "ClickCommand",
                typeof(ICommand),
                typeof(ConnectButton));

        public ICommand ClickCommand
        {
            get => (ICommand)GetValue(ClickCommandProperty);

            set => SetValue(ClickCommandProperty, value);
        }

        public ConnectButton()
        {
            InitializeComponent();
            Button.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClickCommand.Execute(DataContext);
        }
    }
}
