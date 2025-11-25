using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Konyvtar
{
	public partial class MainWindow : Window
	{
		string adatFajl = "olvasok.txt";
		List<Olvaso> olvasoLista = new List<Olvaso>();

		public MainWindow()
		{
			InitializeComponent();
			AdatokBetoltese();
			ListaFrissit();
		}

		private void btnMentes_Click(object sender, RoutedEventArgs e)
		{
			// Életkor validálás
			if (!int.TryParse(tbEletkor.Text, out int kor))
			{
				tbUzenet.Text = "Hibás életkor!";
				return;
			}

			// Műfaj
			ComboBoxItem elem = cbMufaj.SelectedItem as ComboBoxItem;
			string mufaj = elem?.Content.ToString() ?? "";

			// Értesítések
			bool hir = chkHirlevel.IsChecked == true;
			bool sms = chkSms.IsChecked == true;

			// Tagság
			string tagsagTipus = "";
			if (rbNormal.IsChecked == true) tagsagTipus = "Normál";
			if (rbDiak.IsChecked == true) tagsagTipus = "Diák";
			if (rbNyugdijas.IsChecked == true) tagsagTipus = "Nyugdíjas";

			// Új olvasó
			Olvaso ujOlvaso = new Olvaso()
			{
				Nev = tbNev.Text,
				Eletkor = kor,
				Mufaj = mufaj,
				Hirlevel = hir,
				SmsErtesites = sms,
				Tagsag = tagsagTipus
			};

			olvasoLista.Add(ujOlvaso);

			// Fájlba írás
			using (StreamWriter sw = new StreamWriter(adatFajl, true))
			{
				sw.WriteLine(ujOlvaso.ToString());
			}

			ListaFrissit();
			tbUzenet.Text = "Sikeres regisztráció!";
		}

		private void AdatokBetoltese()
		{
			if (!File.Exists(adatFajl)) return;

			foreach (var sor in File.ReadAllLines(adatFajl))
			{
				olvasoLista.Add(Olvaso.FromString(sor));
			}
		}

		private void ListaFrissit()
		{
			lbOlvasok.Items.Clear();

			foreach (var o in olvasoLista)
			{
				lbOlvasok.Items.Add(o.Nev);
			}
		}
	}
}
