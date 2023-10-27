# vrpointer

## Julkaisu

Luotettavan osoittimen luominen virtuaalitodellisuus-sovellukseen.
Nykyiset VR-laitteet tarjoavat erittäin tarkan käden seurannan, mukaan lukien mikroliikkeet ja värinät. Tämä tarkkuus voi aiheuttaa ongelmia, kuten osoittimen epävakautta. Ratkaisuksi kehitimme algoritmin, joka suodattaa käden liikkeen ja tekee osoittimen käytöstä luotettavampaa.
Käyttäjän käden liikkeet 3D-avaruudessa ovat yleensä tasaisia, mutta käden orientaation epävakaus eri akseleilla on ongelmallista ja sitä pyritään suodattamaan.
Esimerkki-sovellus tehdään Unityssä. Algoritmi luo uuden Transform-objektin osoittimelle ja säätää sen orientaatiota suhteessa käyttäjän ohjaimeen. Erona on, että osoittimen nopeus kohti ohjaimen asentoa skaalautuu osoittimen ja ohjaimen välisen kulmaeron mukaan. Pienillä kulmaeroilla osoitin kääntyy hitaasti, ja suuremmilla eroilla nopeammin.
Tämä minimoi käden mikroliikkeiden vaikutuksen osoittimeen ja tekee siitä vakautetun myös kaukaisiin kohteisiin osoitettaessa. Algoritmi on yleiskäyttöinen ja soveltuu muihin samankaltaisiin sovelluskohteisiin, jossa epävakautta halutaan tasata.

    void MoveLine()
    {
    float smoothing; // Viivan tasauksen vahvuuteen käytettävä muuttuja

    // Lasketaan tämänhetkinen kulma laserosoittimen ja käyttäjän ohjaimen välillä
    float theAngle = Quaternion.Angle(Line.rotation, xrController.transform.rotation;
        
    // Lasketaan smoothing arvo. AngleMultiplier on Unity editorissa käytettävä arvo,
    // jolla viivan kääntymisnopeuden voi määrittää sopivaksi itselle.
    // Tätä arvoa käyttäjä haluaa luultavimmin itse kontrolloida
    // ikään kuin hiiren herkkyyttä.
    smoothing = angleMultiplier * Mathf.Pow(theAngle, AnglePower) + angleOffset;

    // Estetään viivan liian nopea kääntyminen
    if (smoothing > maxLineRotation) smoothing = maxLineRotation;

    // Käännetään viivaa Quaternion.Lerp komennon avulla kohti ohjaimen senhetkistä asentoa, käyttäen smoothing arvoa.
    Line.rotation = Quaternion.Lerp(Line.rotation,
    xrController.transform.rotation, smoothing * Time.deltaTime);
    }
