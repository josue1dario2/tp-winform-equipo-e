# 🚀 Sistema de Gestión de Catálogo de Artículos 

## 🎓  Información Académica

* **🏛️ Carrera:** Tecnicatura Universitaria en Programación
* **📚 Materia:** Programación III
* **👨‍🏫 Docente a Cargo:** Maximiliano Sar Fernández
* **📅 Año / Cuatrimestre:** 2026 - 2C
* **🌙 Turno / Comisión:** Noche - Comisión 121
* **👥 Equipo de Desarrollo:** Equipo-e

---

##  🎯 Descripción del Proyecto

¿Imagina un software de escritorio capaz de potenciar cualquier tipo de comercio? esta es una aplicación robusta, dinámica y orientada a objetos diseñada para revolucionar la gestión de artículos. 

Nuestra aplicación actúa como el núcleo central del negocio: permite administrar con precisión milimétrica el inventario para que la información pueda ser consumida sin fricciones por múltiples plataformas. 

### ✨ Funcionalidades Estrella
* 📋 **Listado Dinámico:** Visualización clara y rápida de todo el stock de productos.
* 🔍 **Búsqueda Inteligente:** Filtros avanzados por múltiples criterios para encontrar lo que buscas al instante.
* ➕ **Alta y Gestión Completa:** Incorporación, modificación y baja de artículos sin complicaciones.
* 👁️ **Vista Detallada:** Profundiza en cada ítem con toda su información asociada.
* 🏷️ **Control Total de Marcas y Categorías:** Administra catálogos desplegables personalizables en tiempo real.

---

## 🏗️ 🛠️ Arquitectura y Metodología

El desarrollo se estructuró de forma profesional en dos grandes etapas:
* **Etapa 1 📐:** Diseño de la arquitectura, modelado de clases de negocio y diagramación de flujos y pantallas de navegación.
* **Etapa 2 ⚡:** Conexión segura con bases de datos relacionales, implementación de la lógica de negocio y robustas validaciones en UI.

El proyecto implementa con orgullo una arquitectura limpia de **tres capas**:

```
├── 📦 Dominio/           # Entidades y objetos de negocio esenciales
├── ⚙️ Negocio/           # Lógica transaccional y motores de acceso a datos
├── 💻 TP_WinForm_equipo_e/  # Interfaz gráfica moderna e intuitiva (UI)
└── 🛠️ Utilitarios/       # Clases de soporte y herramientas compartidas
```

---

## 🚀 💻 Tecnologías Utilizadas

- **Lenguaje:** `C#` (.NET)
- **Framework UI:** `Windows Forms`
- **Gestor de Base de Datos:** `SQL Server`
- **Patrón de Diseño:** `POO (Programación Orientada a Objetos)` bajo Arquitectura de 3 Capas

---

## 🧩 📦 Entidades del Ecosistema

| Entidad | Atributos Principales | Descripción |
| :--- | :--- | :--- |
| **🛍️ Articulo** | `Id`, `Codigo`, `Nombre`, `Descripcion`, `Precio`, `Marca`, `Categoria`, `Imagenes` | El corazón del sistema con relaciones inteligentes. |
| **🏷️ Marca** | `Id`, `Descripcion` | Fabricantes o marcas seleccionables desde listas desplegables. |
| **📂 Categoria** | `Id`, `Descripcion` | Rubros o clasificaciones para organizar el inventario. |
| **🖼️ Imagen** | `Id`, `IdArticulo`, `Url` | Enlaces dinámicos para potenciar visualmente cada producto. |

---

## 📱 🖥️ Vistas del Sistema

| Ventana / Formulario | ¿Qué puedes hacer aquí? |
| :--- | :--- |
| `PruebaPrincipal` | 🏠 El panel de control principal, equipado con búsquedas rápidas y visualización global. |
| `AdministrarArticulos` | ⚙️ El centro operativo para dar mantenimiento integral al catálogo. |
| `AgregarArticulos` | ✍️ Formulario intuitivo para crear o actualizar productos y sus galerías de imágenes. |
| `DetallesArticulo` | 🔍 Una ventana dedicada a explorar a fondo las especificaciones de cada ítem. |
| `AdministrarMarca` | 🏷️ Módulo dedicado a ampliar y organizar el listado de marcas. |
| `AdministrarCategorias` | 📂 Módulo para configurar las categorías comerciales disponibles. |

---

## 🗄️ 🗂️ Base de Datos

La persistencia de los datos se realiza sobre la base provista por la cátedra. 
* **Script de Inicialización:** `Negocio/script_db/CATALOGO_DB.sql`
* **Tablas Core:** `MARCAS`, `CATEGORIAS`, `ARTICULOS`, `IMAGENES`

---

## 📋 🔄 Metodología de Trabajo y Gestión de Proyecto

Para el desarrollo de este sistema aplicamos un marco de trabajo ágil basado en **Scrum**, adaptado a los tiempos y objetivos de la cursada:

* **Sprints y Planificación:** El proyecto se organizó en iteraciones de trabajo (Sprints). Al inicio de cada ciclo realizamos reuniones de **Sprint Planning** para definir las tareas, priorizar los requerimientos y estimar el esfuerzo técnico necesario.
* **Seguimiento Diario (Dailies):** Mantuvimos una comunicación fluida y constante mediante **Daily Standups** breves para sincronizar avances, alinear el código de las tres capas y destrabar cualquier inconveniente técnico de forma temprana.
* **Tablero y Control de Incidencias:** Toda la gestión operativa se centralizó en **Jira**, donde se crearon historias de usuario, tareas e incidencias (*issues*) para controlar el flujo de trabajo en el tablero ágil. 
* 🔗 **Tablero del Proyecto:** Podes visualizar la estructura y organización de las tareas en nuestro [Tablero de Jira - KAN Board](https://progra3-tp1.atlassian.net/jira/software/projects/KAN/boards/1?filter=&groupBy=none). *(Nota: El acceso al tablero puede requerir permisos de visualización institucionales otorgados por el equipo).*

---

## 👥 🌟 El Equipo detrás del Éxito (Equipo-e)

* **Josué Darío Solís** 💻
* **Germán Andrés Gonzalez** 🚀
* **Fabricio Leonel Bordon** 🎨

---
<p align="center">
  <i>Desarrollado con pasión y código limpio para la cursada 2026. ¡Gracias por visitar nuestro repositorio! 🚀✨</i>
</p>
