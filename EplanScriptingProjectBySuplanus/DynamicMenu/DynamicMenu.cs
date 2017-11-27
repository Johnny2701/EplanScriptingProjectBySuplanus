/*
	NAME....: MenuDemoRemoveEntry
	USAGE...: for EPLAN P8 (v2.09)
	AUTHOR..: S.Benner / BeDaSys
	VERSION.: 2011-05-11
	FUNC....: Demonstriert das dynamische Hinzuf�gen und Entfernen von Men�eintr�gen per Script in EPlan P8
*/
//
using Eplan.EplApi.Scripting;

public class MenueHinzufuegen
{ 	
	// Deklarationen 
	// -------------------------------------------------
	public static uint hndHMenu = new uint(); // Variable f�r die ID des Hauptmen�s
	public static uint hndMenuEntryL = new uint(); // Variable f�r die ID des 2ten Eintrages
	public static uint hndMenuEntryR = new uint(); // Variable f�r die ID des 3ten Eintrages
	public Eplan.EplApi.Gui.Menu DemoHauptMenue = new Eplan.EplApi.Gui.Menu(); // Das Men�objekt
	//
	// Anlegen der Aktionen f�r die Men�punkte
	// -------------------------------------------------
	//
	// Action: Umschalten auf LINKS
	[DeclareAction("actLinks")] 
	public void actLinks() 
	{
		// Meldung ausgeben
		System.Windows.Forms.MessageBox.Show("Schalte um auf LINKS");
		// Men�eintrag "Links" entfernen
		DemoHauptMenue.RemoveMenuItem(hndMenuEntryL);
		// Men�eintragsID auf 0 setzen
		hndMenuEntryL = 0;
		// Men�eintrag "Rechts" hinzuf�gen falls er nicht vorhanden ist
		if (hndMenuEntryR == 0) {
			hndMenuEntryR = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
				"Rechts", //Eintragsname,
				"actRechts", // Eintragsaktion,
				"Hiermit schalte ich um auf Rechts",//  Statustext,
				hndHMenu, //  Men�-ID,
				1, // Eintragsposition(1= hinten bzw 0= vorne),
				false, // TrennerDavor,
				false); // TrennerDanach);
			}
	}
	//
	// Umschalten auf RECHTS
	[DeclareAction("actRechts")] 
	public void actRechts()	
	{
		// Meldung ausgeben
		System.Windows.Forms.MessageBox.Show("Schalte um auf RECHTS");
		// Men�eintrag "Rechts" entfernen
		DemoHauptMenue.RemoveMenuItem(hndMenuEntryR);
		// Men�eintragsID auf 0 setzen
		hndMenuEntryR = 0;
		// Men�eintrag "Links" hinzuf�gen falls er nicht vorhanden ist
		if (hndMenuEntryL == 0) {
			hndMenuEntryL = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
				"Links", //Eintragsname,
				"actLinks", // Eintragsaktion,
				"Hiermit schalte ich um auf LINKS",//  Statustext,
				hndHMenu, //  Men�-ID,
				1, // Eintragsposition(1= hinten bzw 0= vorne),
				false, // TrennerDavor,
				false); // TrennerDanach);
			}
	}
	//
	// Umschalten auf Links & Rechts
	[DeclareAction("actLinksRechts")]
	public void actLinksRechts()	
	{
		// Meldung ausgeben
		System.Windows.Forms.MessageBox.Show("Schalte um auf Links & Rechts");
		// Men�eintrag "Links" hinzuf�gen falls er nicht vorhanden ist
		if (hndMenuEntryL == 0) {
			hndMenuEntryL = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
				"Links", //Eintragsname,
				"actLinks", // Eintragsaktion,
				"Hiermit schalte ich um auf LINKS",//  Statustext,
				hndHMenu, //  Men�-ID,
				1, // Eintragsposition(1= hinten bzw 0= vorne),
				false, // TrennerDavor,
				false); // TrennerDanach);
			}
		// Men�eintrag "Rechts" hinzuf�gen falls er nicht vorhanden ist
		if (hndMenuEntryR == 0) {
			hndMenuEntryR = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
				"Rechts", //Eintragsname,
				"actRechts", // Eintragsaktion,
				"Hiermit schalte ich um auf Rechts",//  Statustext,
				hndHMenu, //  Men�-ID,
				1, // Eintragsposition(1= hinten bzw 0= vorne),
				false, // TrennerDavor,
				false); // TrennerDanach);
			}
	}
	//	
	// Anlegen des Men�s
	// -------------------------------------------------
	[DeclareMenu]
	public void MenuFunction()
	{
		// Hauptmen� inkl Eintrag "Links und Rechts"
		hndHMenu = DemoHauptMenue.AddMainMenu(	// .AddMainMenu(
			"Demo L/R Umschaltung",	// Men�name,
			"Fenster", //  RechtsNebenMen�Name, 
			"Links und Rechts", // Eintragsname,
			"actLinksRechts", // Eintragsaktion,
			"Umschaltung auf Links & Rechts", // Statustext,
			1); //Eintragsposition(1= hinten bzw 0= vorne)		
		hndMenuEntryL = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
			"Links", //Eintragsname,
			"actLinks", // Eintragsaktion,
			"Hiermit schalte ich um auf LINKS",//  Statustext,
			hndHMenu, //  Men�-ID,
			1, // Eintragsposition(1= hinten bzw 0= vorne),
			false, // TrennerDavor,
			false); // TrennerDanach);
		hndMenuEntryR = DemoHauptMenue.AddMenuItem(	// .AddMenuItem(
			"Rechts", //Eintragsname,
			"actRechts", // Eintragsaktion,
			"Hiermit schalte ich um auf Rechts",//  Statustext,
			hndHMenu, //  Men�-ID,
			1, // Eintragsposition(1= hinten bzw 0= vorne),
			false, // TrennerDavor,
			false); // TrennerDanach);
	}
}
