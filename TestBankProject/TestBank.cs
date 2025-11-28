namespace TestBankProject
{
	public class TestBank
	{
		Bank bank;
		[SetUp]
		public void Setup()
		{
			bank = new Bank();
		}

		[Test]
		public void UjSzamla_NullNev_ArgumentNullExceptiont()
		{
			Assert.Throws<ArgumentNullException>(() => bank.UjSzamla(null, "1234"));
		}

		[Test]
		public void UjSzamla_NullSzamlaszam_ArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => bank.UjSzamla("Teszt Elek", null));
		}

		[Test]
		public void UjSzamla_ErvenyesErtekekkel_NemDobKivetelt()
		{
			Assert.DoesNotThrow(() => bank.UjSzamla("Teszt Elek", "1234"));
		}

		[Test]
		public void UjSzamla_DuplikaltSzamlaszam_ArgumentException()
		{
			bank.UjSzamla("Gipsz Jakab", "1234");
			Assert.Throws<ArgumentException>(() => bank.UjSzamla("Teszt Elek", "1234"));
		}

		[Test]
		public void UjSzamla_DuplikaltNev_NemDobKivetelt()
		{
			bank.UjSzamla("Teszt Elek", "6789");
			Assert.DoesNotThrow(() => bank.UjSzamla("Teszt Elek", "1234"));
		}

		[Test]
		public void UjSzamla_ErvenyesErtekekkel_Egyenleg0()
		{
			bank.UjSzamla("Teszt Elek", "1234");
			Assert.That(bank.Egyenleg("1234"), Is.Zero);
		}

		[Test]
		public void Egyenleg_NullSzamlaszam_ArgumentNullException()
		{
			bank.UjSzamla("Teszt Elek", "1234");

			Assert.Throws<ArgumentNullException>(() =>  bank.Egyenleg(null));
		}


		[Test]
		public void Egyenleg_UresSzamlaszam_ArgumentException()
		{
			bank.UjSzamla("Teszt Elek", "1234");

			Assert.Throws<ArgumentException>(() => bank.Egyenleg(""));
		}

		[Test]
		public void Egyenleg_BetuASzamlaszamban_ArgumentException()
		{
			bank.UjSzamla("Teszt Elek", "1234");

			Assert.Throws<ArgumentException>(() => bank.Egyenleg("abcd"));
		}

		[Test]
		public void Egyenleg_NemLetezoSzamlaszam_HibasSzamlaszamException()
		{
			bank.UjSzamla("Teszt Elek", "1234");

			Assert.Throws<HibasSzamlaszamException>(() => bank.Egyenleg("9876"));
		}

		[Test]
		public void Egyenleg_ErvenyesSzamlaszammal_NemDobKivetelt()
		{
			bank.UjSzamla("Teszt Elek", "1234-5678");

			Assert.DoesNotThrow(() => bank.Egyenleg("1234-5678"));
		}

		[Test]
		public void EgyenlegFeltolt_ErvenyesErtekekkel_AzEgyenlegMegvaltozik()
		{
			bank.UjSzamla("Teszt Elek", "1234");

			bank.EgyenlegFeltolt("1234", 10000);

			Assert.That(bank.Egyenleg("1234"), Is.EqualTo(10000));
		}

		/*
		EgyenlegFeltolt
		- Számlaszám null - kivétel
		- Számlaszám üres - kivétel
		- Számlaszám szöveget tartalmaz - kivétel
		- Számlaszám nem létezik - kivétel
		- összeg 0 - kivétel
		- Létezõ számlaszám, érvényes egyenleg - nem dob kivételt
		- [Az összeg rákerül a számlára - új egyenleg = feltöltött egyenleg]
		- Több számla esetén, az összeg a megfelelõ számlára kerül, a többi változatlan marad
		- Többször ugyan arra a számlára töltés - Az összeg hozzáadódik nem felülírja
		- Ugyan az a tulajdonos több számlával - megfelelõ számlára tölt

		Utal
		- kivételek: honnan/hova null, üres, szöveg, nem létezik | összeg 0
		- Az egyenlegek megváltoznak utaláskor
		- A számlaszámon lévõ teljes egyenleg átutalható
		- A számlaszámon lévõ egyenlegnél nagyobb egyenleg nem utalható át - Az egyenlegek nem változnak
		- Több számla esetén csak a megfelelõ számlák egyenlege változik
		 */
	}
}