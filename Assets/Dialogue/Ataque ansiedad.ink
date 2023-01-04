VAR final=0

Tienes problemas para respirar y casi no se puede mantener en pie. #speaker:Diana #portrait:diana #layout:left
Diana está teniendo un ataque de ansiedad. Si no me acuerdo mal, hoy tenía un examen de irregular verbs... #speaker:Dra. Juan #portrait:dra_juan #layout:right
-> primero

=== primero ===
#speaker:Dra. Juan #portrait:dra_juan #layout:right
"Oye, si puedes entenderme..."
    * ["Intenta respirar como lo hago yo, expira… suelta… expira… suelta…"]
        ~ final = final+4
        -- Le cuesta al principio, pero parece que va respirando mejor imitando tu respiración. #speaker:Diana #portrait:diana #layout:left
        -> segundo
    * ["Enserio, ¿irregular verbs? Pero si eso es lo más fácil que te pueden poner"]
        -- Esta alumna se está estresando más y ha comenzando a llorar.
        -> segundo
    * ["¿Cómo te llamas?"]
        ~ final = final+2
        -- “A.. aaa.. aa…” #speaker:Diana #portrait:diana #layout:left
        -- No se le entiende nada, pero parece estar más calmado. #speaker:Dra. Juan #portrait:dra_juan #layout:right
        -> segundo

=== segundo ===
Debería distraerla y hacer que no piense en el examen ni en el ataque de ansiedad… #speaker:Dra. Juan #portrait:dra_juan #layout:right
    * [“Very well. We are going to do the five, four, three, two, one exercise. Do you understand?”]
        -- Su respiración no mejora y suelta un sollozo. #speaker:Diana #portrait:diana #layout:left
        -> tercero
    * [“Sigue respirando así.”]
        ~ final = final+2
        -- Sigue con los ejercicios de respiracion pero no parece mejorar mucho. #speaker:Diana #portrait:diana #layout:left
        ->  tercero
    * [“Lo estás haciendo bien, sigue con los ejercicios de respiración. Y en nada hacemos el 5, 4, 3, 2, 1.”]
        ~ final = final+4
        -- Sigue intentándolo y parece un poco más calmado. Tiene su atención en ti. #speaker:Diana #portrait:diana #layout:left
        -> tercero

=== tercero ===
“Bien, comencemos con el ejercicio del 5, 4, 3, 2, 1.” #speaker:Dra. Juan #portrait:dra_juan #layout:right
    * [“Dime 10 cosas que puedas ver”]
        ~ final = final+2
        -- “Baaaaaaaaaaa… baaaaaaa… taaa. Ooo– jjjj… oooo. ” Se corta de repente, llorando por el estrés de decir tantas cosas. #speaker:Diana #portrait:diana #layout:left
        -- Ay me he pasado de cosas.#speaker:Dra. Juan #portrait:dra_juan #layout:right
        -> eventoFinal
    * [“Tell me 5 things that you can see. In english, please”]
        -- Suelta un grito ahogado. #speaker:Diana #portrait:diana #layout:left
        -> eventoFinal
    * [“Intenta decirme 5 cosas que puedes ver”]
       ~ final = final+4
       -- “Baaaa…. baaaaaa…. baaa– ta. Teee… teeeeeee-” #speaker:Diana #portrait:diana #layout:left
       -- No lo hace muy bien, pero se está centrando en el ejercicio. Eso es bueno. #speaker:Dra. Juan #portrait:dra_juan #layout:right
        -> eventoFinal
        
== eventoFinal ==        
{
- final > 9:
    Va haciendo el ejercicio del 5, 4, 3, 2, 1 como puede. #speaker:Diana #portrait:diana #layout:left
    Al final se calma y llamamos a sus padres para que lo vengan a recoger.#speaker:Dra. Juan #portrait:dra_juan #layout:right
- else:
    El alumno empieza a convulsionar y a gritar. #speaker:Diana #portrait:diana #layout:left
    Suspira. "Esto me lo descuentan del sueldo. ... Espero que no me denuncien."#speaker:Dra. Juan #portrait:dra_juan #layout:right
}
->END