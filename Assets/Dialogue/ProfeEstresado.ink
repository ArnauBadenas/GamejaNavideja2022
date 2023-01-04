VAR final=0

#speaker: Dra. Juan
"¿Estás bien?"
#speaker: Harvey
"Oh, perdona. Estaba un poco agobiado con la clase, últimamente me tienen hasta aquí…"
#speaker: Dra. Juan
"Vaya, parece grave ¿Qué es lo que sucede?"

#speaker: Harvey
A2: Sí, algunos alumnos se dedican a reírse de mi tono de voz, realmente no puedo más, creo que tendré que dimitir.

-> primero

=== primero ===
#speaker: Dra. Juan
"¿Que ha ocurrido?"
#speaker: Alumno
"Nada Dra. Juan, no se preocupe"
Se seca algunas lagrimas que tiene en las mejillas con las mangas.
#speaker: Dra. Juan
    * ["No se preocupe profesor Harvey, no tiene usted la culpa."]
        ~ final = final+4
        
       -- Tenga en cuenta que algunos alumnos se sienten mal consigo mismos y recurren a la violencia para intentar atraer la atención y pedir ayuda para ellos mismos.

        #speaker: Harevy
        -- Pero… ¿Por qué hacerlo de esta manera? Sienta horrible que estén un trimestre entero haciéndome sentir así 
        -> segundo
        
    * ["Si, los alumnos son un poco capullos, ¿verdad?"]
        ~ final = final+2
        
        -- "Supongo…" #speaker: Harevy
        -- "Anda profesor, que son solo unos niños…"#speaker: Dra. Juan
        
        -> segundo
    * ["A ver la verdad es que su voz es bastante aguda, los niños tienen razón."]
        -- ¿De verdad, está con ellos?  #speaker: Harevy
        -- Solloza #speaker: Harvey 
        -> segundo

=== segundo ===
#Dra. Juan
"Supongo que deberiamos  
    * [“Si quiere podemos tratar de hablar con sus tutores, ese podria ayudar”]
        ~ final = final+4
        -- Es posible… #speaker: Harvey
        -> eventoFinal
        
    * ["Aunque si se enteran de que les has reportado, quizás se meteran mas con usted ”]
        ~ final = final+2
        -- Te mira sorprendido .  #speaker: Harvey
        -- "¿Usted cree que puede ir a peor?" #speaker: Harvey
        -- "Es una posibilidad, pero quién sabe…" #Dra. Juan
        ->  eventoFinal
    * [“¿Vas a meter a los pobres alumnos en problemas por esta tontería? Madure ”]
        -- Se encuentra visiblemente sorprendido y preocupado. #speaker: Harvey
        -> eventoFinal


        
== eventoFinal ==        
{
- final > 9:
  #speaker: Harvey
Te mira más calmado y asiente con la cabeza
  "Si tiene razon, no deberia darle tantas vueltas"
  
  #speaker: Dra. Juan
Exacto, tenga en cuenta que algunos alumnos se sienten mal consigo mismos y recurren a la violencia para intentar atraer la atención y pedir ayuda para ellos mismos.

    
- else:
 #speaker: Harvey
Esta visiblemente intranquilo 
"Si, desde luego no puedo seguir trabajando en este entorno. " 
Lo lamento, pero es usted muy débil, no se como quiere ser profesor si no puede aguantar unas pocas burlas de los niños. #speaker: Dra. Juan
}
->END