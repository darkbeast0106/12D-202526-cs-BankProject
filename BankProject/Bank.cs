namespace BankProject
{
    /// <summary>
    /// Bank műveleteit végrehajtó osztály.
    /// </summary>
    public class Bank
    {
        List<Szamla> szamlak = new List<Szamla>();
        /// <summary>
        /// Új számlát nyit a megadott névvel, számlaszámmal, 0 Ft egyenleggel
        /// </summary>
        /// <param name="nev">A számla tulajdonosának neve</param>
        /// <param name="szamlaszam">A számla számlaszáma</param>
        /// <exception cref="ArgumentNullException">A név és a számlaszám nem lehet null</exception>
        /// <exception cref="ArgumentException">A név és a számlaszám nem lehet üres
        /// A számlaszámmal nem létezhet számla
        /// A számlaszám számot, szóközt és kötőjelet tartalmazhat</exception>
        public void UjSzamla(string nev, string szamlaszam)
        {
            if (nev == null)
            {
                throw new ArgumentNullException(nameof(nev));
            }
            if (szamlaszam == null)
            {
                throw new ArgumentNullException(nameof(szamlaszam));
            }

            // Eldöntés tétel
            int index = 0;
            // Végigmegyünk a listán addig amíg nem találunk a megadott feltéllel elemet
            while (index < this.szamlak.Count && this.szamlak[index].Szamlaszam != szamlaszam)
            {
                index++;
            }
			// Ha nem érünk el a lista végére, akkor létezik ilyen elem
			if (index < this.szamlak.Count)
            {
                throw new ArgumentException("A megadott számlaszámmal már létezik számla",
                    nameof(szamlaszam));
            }

            this.szamlak.Add(new Szamla(nev, szamlaszam));
        }

        /// <summary>
        /// Lekérdezi az adott számlán lévő pénzösszeget
        /// </summary>
        /// <param name="szamlaszam">A számla számlaszáma, aminek az egyenlegét keressük</param>
        /// <returns>A számlán lévő egyenleg</returns>
        /// <exception cref="ArgumentNullException">A számlaszám nem lehet null</exception>
        /// <exception cref="ArgumentException">A számlaszám számot, szóközt és kötőjelet tartalmazhat</exception>
        /// <exception cref="HibasSzamlaszamException">A megadott számlaszámmal nem létezik számla</exception>
        public ulong Egyenleg(string szamlaszam)
        {
            return 0;
        }

        /// <summary>
        /// Egy létező számlára pénzt helyez
        /// </summary>
        /// <param name="szamlaszam">A számla számlaszáma, amire pénzt helyez</param>
        /// <param name="osszeg">A számlára helyezendő pénzösszeg</param>
        /// <exception cref="ArgumentNullException">A számlaszám nem lehet null</exception>
        /// <exception cref="ArgumentException">Az összeg csak pozitív lehet.
        /// A számlaszám számot, szóközt és kötőjelet tartalmazhat</exception>
        /// <exception cref="HibasSzamlaszamException">A megadott számlaszámmal nem létezik számla</exception>
        public void EgyenlegFeltolt(string szamlaszam, ulong osszeg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Két számla között utal.
        /// Ha nincs elég pénz a forrás számlán, akkor false értékkel tér vissza
        /// </summary>
        /// <param name="honnan">A forrás számla számlaszáma</param>
        /// <param name="hova">A cél számla számlaszáma</param>
        /// <param name="osszeg">Az átutalandó egyenleg</param>
        /// <returns>Az utalás sikeressége</returns>
        /// <exception cref="ArgumentNullException">A forrás és cél számlaszám nem lehet null</exception>
        /// <exception cref="ArgumentException">Az összeg csak pozitív lehet.
        /// A számlaszám számot, szóközt és kötőjelet tartalmazhat</exception>
        /// <exception cref="HibasSzamlaszamException">A megadott számlaszámmal nem létezik számla</exception>
        public bool Utal(string honnan, string hova, ulong osszeg)
        {
            throw new NotImplementedException();
        }

		private class Szamla
		{
			public Szamla(string nev, string szamlaszam)
			{
				Nev = nev;
				Szamlaszam = szamlaszam;
			}

			public string Nev { get; set; }
            public string Szamlaszam { get; set; }
            public ulong Egyenleg { get; set; }
		}
	}
}