# 🧮 Math Exam 3D - Prueba Técnica en Unity

## 🎮 Descripción General

**Math Exam 3D** es un juego educativo interactivo desarrollado en Unity, donde el jugador explora un entorno 3D para resolver problemas matemáticos.

A diferencia de los cuestionarios tradicionales basados en UI, este proyecto transforma la experiencia en una mecánica de exploración:
el jugador debe **moverse por el entorno e interactuar con objetos** para encontrar la respuesta correcta.

---

## 🚀 Funcionalidades

* 🎯 **Sistema de preguntas dinámico**

  * Las preguntas se cargan desde un archivo JSON
  * Arquitectura basada en datos (data-driven)
  * Fácil de escalar y extender

* 🌳 **Gameplay basado en interacción 3D**

  * El jugador navega un entorno 3D
  * Las respuestas están distribuidas en objetos del escenario (árboles, rocas, etc.)
  * La interacción determina si la respuesta es correcta

* 🖥️ **Sistema de UI**

  * Muestra la pregunta actual dinámicamente
  * Interfaz limpia y minimalista

* 🧮 **Sistema de resultados**

  * Registra respuestas correctas e incorrectas
  * Muestra puntaje final y porcentaje

* 🧾 **Pizarra para dibujar (Feature opcional)**

  * Permite dibujar con el mouse
  * Implementada con el **New Input System de Unity**
  * Incluye:

    * Dibujo fluido con interpolación
    * Grosor de pincel configurable
    * Función de limpiar
    * Activación/desactivación durante el juego

---

## 🧠 Aspectos Técnicos Destacados

* 🔹 **Unity 6 + C#**
* 🔹 **New Input System (manejo moderno de input)**
* 🔹 **Arquitectura basada en JSON**
* 🔹 **Separación de responsabilidades (Datos / Lógica / UI)**
* 🔹 **Configuración dinámica de objetos en runtime**
* 🔹 **Sistema de dibujo personalizado usando Texture2D**

---

## 📂 Estructura del Proyecto

```
Assets/
│
├── Scripts/
│   ├── Core/           # Lógica principal (QuestionManager, AnswerObject)
│   ├── Data/           # Modelos de datos (QuestionData)
│   └── UI/             # Sistemas de UI (DrawingBoard, Toggle)
│
├── Resources/
│   └── questions.json  # Fuente de datos de preguntas
│
├── Scenes/
│   └── MainScene
```

---

## ⚙️ Cómo Funciona

1. Las preguntas se cargan desde un archivo JSON en tiempo de ejecución
2. Para cada pregunta:

   * Se muestra en pantalla
   * Se distribuyen las respuestas aleatoriamente
3. Los objetos del entorno reciben dinámicamente:

   * Texto de respuesta
   * Estado (correcto/incorrecto)
4. El jugador explora el entorno y selecciona una respuesta
5. El sistema valida la respuesta y avanza
6. Al final se muestran los resultados

---

## 🎮 Controles

| Acción          | Input           |
| --------------- | --------------- |
| Mover jugador   | WASD / Flechas  |
| Seleccionar     | Click del mouse |
| Abrir pizarra   | Botón UI        |
| Dibujar         | Arrastrar mouse |
| Limpiar pizarra | Botón UI        |

---

## 🧪 Posibles Mejoras

* Añadir animaciones y feedback visual (acierto/error)
* Reemplazar objetos básicos por assets más detallados
* Incorporar efectos de sonido y música
* Implementar niveles de dificultad
* Añadir temporizador por pregunta
* Mejorar el sistema de dibujo (suavizado, colores, presión)

---

## 🏁 Conclusión

Este proyecto demuestra la capacidad de:

* Diseñar sistemas de gameplay interactivos
* Trabajar con input en tiempo real y UI
* Estructurar código escalable y mantenible
* Integrar múltiples sistemas de Unity en una experiencia coherente

---

## 👤 Autor

**Esteban Garrido**
Fullstack Developer con enfoque en backend, explorando el desarrollo de videojuegos con Unity.

---
