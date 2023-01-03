VAR final=0

-> primero

=== primero ===
#speaker: Dra. Juan
"Oye, si puedes entenderme..."
    * ["Intenta respirar como lo hago yo, expira… suelta… expira… suelta…"]
        ~ final = final+4
        #speaker: Alumno
        -- Le cuesta al principio, pero parece que va respirando mejor imitando tu respiración.
        -> segundo
    * ["¿Cómo te llamas?"]
        ~ final = final+2
        -- “A.. aaa.. aa…” #speaker: Alumno
        -- No se le entiende nada, pero parece estar más calmado. #speaker: Dra. Juan
        -> segundo
    * ["Enserio, ¿irregular verbs? Pero si eso es lo más fácil que te pueden poner"]
        -- Visiblemente el alumno se estresa más y esta comenzando a llorar. #speaker: Dra. Juan
        -> segundo

=== segundo ===
#Dra. Juan
Debería distraerlo y hacer que no piense en el examen ni en el ataque de ansiedad…
    * [“Lo estás haciendo bien, sigue con los ejercicios de respiración. Y en nada hacemos el 5, 4, 3, 2, 1.”]
        ~ final = final+4
        -- Sigue intentándolo y parece un poco más calmado. Tiene su atención en ti. #Alumno
        -> tercero
    * [“Sigue respirando así.”]
        ~ final = final+2
        -- Sigue con los ejercicios de respiracion pero no parece mejorar mucho. #Alumno
        ->  tercero
    * [“Very well. We are going to do the five, four, three, two, one exercise. Do you understand?”]
        -- Su respiración no mejora y suelta un sollozo. #Alumno
        -> tercero

=== tercero ===
#Dra. Juan
- “Bien, comencemos con el ejercicio del 5, 4, 3, 2, 1.”
    * [“Intenta decirme 5 cosas que puedes ver”]
       ~ final = final+4
       -- “Baaaa…. baaaaaa…. baaa– ta. Teee… teeeeeee-” #Alumno
       -- No lo hace muy bien, pero se está centrando en el ejercicio. Eso es bueno. #Dra. Juan
        -> eventoFinal
    * [“Dime 10 cosas que puedas ver”]
        ~ final = final+2
        -- “Baaaaaaaaaaa… baaaaaaa… taaa. Ooo– jjjj… oooo. ” Se corta de repente, llorando por el estrés de decir tantas cosas. #Alumno
        -- Ay me he pasado de cosas. #Dra. Juan
        -> eventoFinal
    * [“Tell me 5 things that you can see. In english, please”]
        -- Suelta un grito ahogado.
        -> eventoFinal
        
== eventoFinal ==        
{
- final > 9:
    Va haciendo el ejercicio del 5, 4, 3, 2, 1 como puede. #Alumno
    Al final se calma y llamamos a sus padres para que lo vengan a recoger. #Dra. Juan
- else:
    El alumno empieza a convulsionar y a gritar. #Alumno
    Suspira. "Esto me lo descuentan del sueldo. ... Espero que no me denuncien." #Dra.Juan
}
->END