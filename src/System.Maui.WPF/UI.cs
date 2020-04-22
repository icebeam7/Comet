﻿using System.Maui.WPF.Handlers;
using System.Maui.WPF.Services;
using System.Windows;

namespace System.Maui.WPF
{
	public static class UI
	{
		private static bool _hasInitialized;

		public static void Init()
		{
			if (_hasInitialized) return;
			_hasInitialized = true;

			// Controls
			Registrar.Handlers.Register<Button, ButtonHandler>();
			Registrar.Handlers.Register<Image, ImageHandler>();
			Registrar.Handlers.Register<Label, TextHandler>();
			Registrar.Handlers.Register<Entry, TextFieldHandler>();
			Registrar.Handlers.Register<Switch, ToggleHandler>();
			Registrar.Handlers.Register<RadioButton, RadioButtonHandler>();
			//Registrar.Handlers.Register<WebView, WebViewHandler> ();

			// Containers
			Registrar.Handlers.Register<ScrollView, ScrollViewHandler>();
			Registrar.Handlers.Register<ListView, ListViewHandler>();
			Registrar.Handlers.Register<View, ViewHandler>();
			Registrar.Handlers.Register<ContentView, ContentViewHandler>();
			Registrar.Handlers.Register<RadioGroup, RadioGroupHandler>();

			// Common Layout
			Registrar.Handlers.Register<Spacer, SpacerHandler>();

			// Native Layout
			//Registrar.Handlers.Register<VStack, VStackHandler>();
			//Registrar.Handlers.Register<HStack, HStackHandler>();

			// Managed Layout
			Registrar.Handlers.Register<VStack, ManagedVStackHandler>();
			Registrar.Handlers.Register<HStack, ManagedHStackHandler>();
			Registrar.Handlers.Register<ZStack, ManagedZStackHandler>();

			Device.BitmapService = new WPFBitmapService();

			ThreadHelper.JoinableTaskContext = new Microsoft.VisualStudio.Threading.JoinableTaskContext();
			ThreadHelper.SetFireOnMainThread( a => Application.Current.Dispatcher.Invoke(a));

			ListView.HandlerSupportsVirtualization = false;
		}
	}
}
