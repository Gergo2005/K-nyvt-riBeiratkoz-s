using System;

namespace Konyvtar
{
	public class Olvaso
	{
		// Alapértékek
		private string nev = "";
		private int eletkor = 0;
		private string mufaj = "";
		private bool hirlevel = false;
		private bool sms = false;
		private string tagsag = "";

		// Tulajdonságok
		public string Nev { get => nev; set => nev = value; }
		public int Eletkor { get => eletkor; set => eletkor = value; }
		public string Mufaj { get => mufaj; set => mufaj = value; }
		public bool Hirlevel { get => hirlevel; set => hirlevel = value; }
		public bool SmsErtesites { get => sms; set => sms = value; }
		public string Tagsag { get => tagsag; set => tagsag = value; }

		// ToString → fájlba írás formátuma
		public override string ToString()
		{
			return $"{Nev}|{Eletkor}|{Mufaj}|{Hirlevel}|{SmsErtesites}|{Tagsag}";
		}

		// FromString → fájlból visszaalakítás
		public static Olvaso FromString(string sor)
		{
			var adat = sor.Split('|');

			return new Olvaso
			{
				Nev = adat[0],
				Eletkor = int.Parse(adat[1]),
				Mufaj = adat[2],
				Hirlevel = bool.Parse(adat[3]),
				SmsErtesites = bool.Parse(adat[4]),
				Tagsag = adat[5]
			};
		}
	}
}
