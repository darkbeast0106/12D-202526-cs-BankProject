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

	}
}