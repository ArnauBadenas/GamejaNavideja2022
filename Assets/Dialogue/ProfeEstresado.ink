VAR final=0

"¿Estás bien?" #speaker:Dra. Juan #portrait:dra_juan #layout:right
"Oh, perdona. Estaba un poco agobiado con la clase, últimamente me tienen hasta aquí…" #speaker:Harvey #portrait:harvey #layout:left
"Vaya, parece grave ¿Qué es lo que sucede?" #speaker:Dra. Juan #portrait:dra_juan #layout:right
"Sí, algunos alumnos se dedican a reírse de mi tono de voz, realmente no puedo más, creo que tendré que dimitir." #speaker:Harvey #portrait:harvey #layout:left
Este es un problema habitual con los profesores substitutos. #speaker:Dra. Juan #portrait:dra_juan #layout:right
    * ["No se preocupe profesor Harvey, no tiene usted la culpa."]
        ~ final = final+4
        --"Tenga en cuenta que algunos alumnos se sienten mal consigo mismos y recurren a la violencia para intentar atraer la atención y pedir ayuda para ellos mismos."
        --"Pero… ¿Por qué hacerlo de esta manera? Sienta horrible que estén un trimestre entero haciéndome sentir así." #speaker:Harvey #portrait:harvey #layout:left
        -> segundo
    * ["A ver la verdad es que su voz es bastante aguda, los niños tienen razón."]
        -- "¿De verdad, está con ellos?" #speaker:Harvey #portrait:harvey #layout:left
        -- Solloza.
        -> segundo
    * ["Si, los alumnos son un poco capullos, ¿verdad?"]
        ~ final = final+2
        --"Supongo…" #speaker:Harvey #portrait:harvey #layout:left
        --"Anda profesor, que son solo unos niños…"#speaker:Dra. Juan #portrait:dra_juan #layout:right
        -> segundo

=== segundo ===
Debo intentar calmar la situación. #speaker:Dra. Juan #portrait:dra_juan #layout:right 
    * ["Aunque si se enteran de que les has reportado, quizás se meteran mas con usted ”]
        ~ final = final+2
        --Te mira sorprendido.  #speaker:Harvey #portrait:harvey #layout:left
        --"¿Usted cree que puede ir a peor?" #speaker:Harvey #portrait:harvey #layout:left
        --"Es una posibilidad, pero quién sabe…" #speaker:Dra. Juan #portrait:dra_juan #layout:right 
        ->  eventoFinal
    * [“Si quiere podemos tratar de hablar con sus tutores, ese podria ayudar”]
        ~ final = final+4
        --"Es posible…" #speaker:Harvey #portrait:harvey #layout:left
        -> eventoFinal
    * [“¿Vas a meter a los pobres alumnos en problemas por esta tontería? Madure ”]
        --Se encuentra visiblemente sorprendido y preocupado. #speaker:Harvey #portrait:harvey #layout:left
        -> eventoFinal

== eventoFinal ==        
{
- final > 4:
Te mira más calmado y asiente con la cabeza.
"Si tiene razon, no deberia darle tantas vueltas." #speaker:Harvey #portrait:harvey #layout:left
  
"Exacto, tenga en cuenta que algunos alumnos se sienten mal consigo mismos y recurren a la violencia para intentar atraer la atención y pedir ayuda para ellos mismos." #speaker:Dra. Juan #portrait:dra_juan #layout:right 
- else:
Esta visiblemente intranquilo. #speaker:Harvey #portrait:harvey #layout:left
"Si, desde luego no puedo seguir trabajando en este entorno. " 
"Lo lamento, pero es usted muy débil, no se como quiere ser profesor si no puede aguantar unas pocas burlas de los niños." #speaker:Dra. Juan #portrait:dra_juan #layout:right 
}
->END