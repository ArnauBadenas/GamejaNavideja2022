VAR final=0
"Me han puesto un 6 en los últimos ejercicios de fisica. ¡Te dije que quería al menos un 9!" #speaker:EstudianteA #portrait:volverdefault #layout:left
"Tus apuntes de Historia son del tema 5. ¡Tenemos un examen mañana y el examen es del tema 6!" #speaker:EstudianteB #portrait:volverdefault #layout:left
"¿Qué está pasando aquí?"#speaker:Dra. Juan #portrait:dra_juan #layout:right
"¡Mierda! Nos han pillado. Será mejor que nos largemos." #speaker:EstudianteA #portrait:volverdefault #layout:left
Está intentando contener las lágrimas. #speaker:Denis #portrait:denis #layout:left
-> primero

=== primero ===
"¿Que ha ocurrido?" #speaker:Dra. Juan #portrait:dra_juan #layout:right
"Nada Dra. Juan, no se preocupe." #speaker:Denis #portrait:denis #layout:left
Se seca algunas lágrimas que tiene en las mejillas con las mangas. #speaker:Dra. Juan #portrait:dra_juan #layout:right
    * ["Estoy obligada a reportar las incidencias que veo, te pido que no me pongas más complicado mi trabajo."]
        ~ final = final+2
        -- "No puedo, seguro que me acaba perjudicando a mí." #speaker:Denis #portrait:denis #layout:left
        -- "Si me lo cuentas haré lo posible para que eso no pase." #speaker:Dra. Juan #portrait:dra_juan #layout:right
        -- Te cuenta por encima lo que ha pasado, pero se nota que está omitiendo mucha información. #speaker:Denis #portrait:denis #layout:left
        -> segundo
    * ["Mira niño si no me dices que está pasando te voy a tener que enviar a dirección."]
        -- Te mira asustado mientras le empiezan a caer las lágrimas. #speaker:Denis #portrait:denis #layout:left
        -> segundo
    * ["Puedes decírmelo, si te preocupan las consecuencias, no habrá ninguna. Estate tranquilo, tan solo busco ayudar."]
        ~ final = final+4
        -- Poco a poco va ganando confianza y te cuenta todo lo que ha pasado. #speaker:Denis #portrait:denis #layout:left
        -> segundo

=== segundo ===
Debería reportar este incidente... #speaker:Dra. Juan #portrait:dra_juan #layout:right
    * [“Vamos a dirrecion ahora mismo, este comportamiento es inadmisible.”]
        -- Niega con la cabeza. #speaker:Denis #portrait:denis #layout:left
        -> eventoFinal
    * [“Entiendo… Sé que quizás piensas que no es lo mejor, pero deberías reportarlo por este comportamiento, yo misma puedo acompañarte.”]
        ~ final = final+4
        -- Te mira pensativo durante unos segundos… #speaker:Denis #portrait:denis #layout:left
        -- Asiente con la cabeza.
        -> eventoFinal
    * ["Hoy hablaré con tus padres para que sepan de lo sucedido, entiende que si el director se entera de que no lo reporté se me puede caer el pelo.”]
        ~ final = final+2
        -- Te mira con cara de sorpresa, pero las lágrimas empiezan a frenar. #speaker:Denis #portrait:denis #layout:left
        ->  eventoFinal

== eventoFinal ==        
{
- final > 4:
Acepta que vayáis juntos a hablar con sus padres. #speaker:Denis #portrait:denis #layout:left
Cuando le preguntas si puedes hablar con los padres de los otros alumnos, asiente con la cabeza.
"Me aseguraré de que esto no vuelva a pasar." #speaker:Dra. Juan #portrait:dra_juan #layout:right
- else:
   Empieza a llorar fuerte por el miedo. #speaker:Denis #portrait:denis #layout:left
    "Por mucho berrinche que montes, no voy a poner mi trabajo en juego por ti." #speaker:Dra. Juan #portrait:dra_juan #layout:right
}
->END