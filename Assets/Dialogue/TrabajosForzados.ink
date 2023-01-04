VAR final=0

#speaker: Estudiante 1 
" Me han puesto un 6 en los últimos ejercicios de fisica. ¡Te dije que quería al menos un 9!"
#speaker: Estudiante 2 
"Tus apuntes de Historia son del tema 5. ¡Tenemos un examen mañana y el examen es del tema 6!"
#speaker: Dra. Juan
"¿Qué está pasando aquí?"

#speaker: Estudiante 1 
A2: ¡Mierda! Nos han pillado. Será mejor que nos largemos.

#speaker: Alumno
Esta intentando contener las lagrimas. 
-> primero

=== primero ===
#speaker: Dra. Juan
"¿Que ha ocurrido?"
#speaker: Alumno
"Nada Dra. Juan, no se preocupe"
Se seca algunas lagrimas que tiene en las mejillas con las mangas.
#speaker: Dra. Juan
    * ["Puedes decírmelo,si te preocupan las consecuencias, no habrá ninguna. Estate tranquilo, tan solo busco ayudar."]
        ~ final = final+4
        #speaker: Alumno
        -- Poco a poco va ganando confianza y te cuenta todo lo que ha pasado. 
        -> segundo
    * ["Estoy obligada a reportar las incidencias que veo, te pido que no me pongas mas complicado mi trabajo. "]
        ~ final = final+2
        -- "No puedo, seguro que me acaba perjudicando a mi" #speaker: Alumno
        -- "Si me lo cuentas haré lo posible para que eso no pase"#speaker: Dra. Juan
        -- Te cuenta por encima lo que ha pasado pero se nota que está omitiendo mucha información  #speaker: Alumno
        -> segundo
    * ["Mira niño si no me dices que está pasando te voy a tener que enviar a dirección"]
        -- Te mira asustado mientras le empiezan a caer las lágrimas  #speaker: Alumno
        -> segundo

=== segundo ===
#Dra. Juan
Debería reportar este incidente... 
    * [“Entiendo… Sé que quizás piensas que no es lo mejor, pero deberías reportarlo por este comportamiento, yo misma puedo acompañarte.”]
        ~ final = final+4
        -- Te mira pensativo durante unos segundos…  #Alumno
        -- Asiente con la cabeza. #Alumno
        -> eventoFinal
    * [Hoy hablaré con tus padres para que sepan de lo sucedido, entiende que si el director se entera de que no lo reporté se me puede caer el pelo. ”]
        ~ final = final+2
        -- Te mira con cara de sorpresa pero las lágrimas empiezan a frenar.  #Alumno
        ->  eventoFinal
    * [“Vamos a dirrecion ahora mismo, este comportamiento es inadmisible”]
        -- Niega con la cabeza #Alumno
        -> eventoFinal


        
== eventoFinal ==        
{
- final > 9:
Acepta que vayáis juntos a hablar con sus padres.  #Alumno
Cuando le preguntas si puedes hablar con los padres de los otros alumnos asiente con la cabeza.
  #Alumno
  “Me asegurare de que esto no vuelva a pasar “ #speaker: Dra. Juan

    
- else:
   Empieza a llorar con fuerza por el miedo. #Alumno
    "Por mucho berrinche que montes, no voy a poner mi trabajo en juego por ti." #speaker: Dra. Juan
}
->END