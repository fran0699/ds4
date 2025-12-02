<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BufeteLegalFL.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Casos Legales - Bufete</title>
    <meta charset="utf-8" />
</head>
<body>
    <form id="formPrincipal" runat="server">
        <div>
            <h1>Solución tecnológica para la gestión de casos legales</h1>

            <h2>1. ¿Cómo resolvería estos problemas con una solución tecnológica?</h2>
            <p>
                Yo resolvería estos problemas desarrollando un sistema web de gestión de casos legales, centralizado y accesible desde cualquier equipo dentro de la firma de abogados.
                Cada caso tendría un expediente digital único donde se registre: cliente, abogado asignado, fechas clave, estado del caso, reuniones, audiencias y documentos asociados. De esta forma, toda la información relevante del caso estará en un solo lugar y no dispersa en hojas de cálculo o documentos sueltos.
                Para evitar la pérdida de información sobre reuniones y vencimientos, yo implementaría un módulo de agenda y actividades del caso, donde se registren audiencias, reuniones y plazos legales con sus fechas y horas. El sistema mostraría listas de actividades pendientes y vencidas, y podría generar alertas visuales (por ejemplo, cambiar el color de las filas o mostrar iconos) cuando se acerquen fechas importantes.
                Para los documentos, yo vincularía cada archivo a un caso específico dentro de una tabla de documentos, guardando la ruta del archivo en el servidor. Así, el abogado podría buscar los documentos filtrando por caso, tipo de documento o fecha de registro.
                Finalmente, al centralizar toda la información en una base de datos SQL Server, garantizo que todos los abogados y asistentes vean la misma información actualizada en tiempo real, evitando la difusión descontrolada de versiones diferentes de un mismo archivo o planilla.
            </p>

            <h2>2. ¿Qué pasos seguiría para desarrollar el sistema?</h2>
            <p>
                Para desarrollar este sistema de forma ordenada, yo seguiría estos pasos:
                1.	Levantamiento de requisitos: me reuniría con los socios, abogados y asistentes para entender cómo trabajan hoy, qué datos manejan, qué reportes necesitan y cuáles son los dolores principales del proceso actual.
                2.	Priorización de funcionalidades: definiría un alcance inicial claro, por ejemplo: gestión de clientes, gestión de abogados, registro de casos, agenda de actividades y registro de documentos relacionados al caso.
                3.	Diseño de la base de datos: a partir de los requisitos, diseñaría un modelo entidad–relación donde se vean claramente las entidades principales (clientes, abogados, casos, actividades y documentos) y sus relaciones.
                4.	Diseño de la arquitectura de la aplicación: elegiría una arquitectura por capas usando ASP.NET Web Forms con C# y SQL Server, separando claramente la capa de presentación (páginas .aspx), la capa de acceso a datos (consultas SQL) y la lógica de negocio.
                5.	Diseño de la interfaz gráfica: haría bocetos simples de las pantallas (wireframes): listado de casos, formulario para registrar/editar casos, pantalla de actividades y una vista general de la agenda.
                6.	Configuración del entorno: crearía la base de datos en SQL Server y el proyecto ASP.NET (.NET Framework) en Visual Studio, definiendo la cadena de conexión en el Web.config.
                7.	Desarrollo iterativo: implementaría primero lo básico (insertar, listar y actualizar casos) y luego iría agregando módulos: clientes, abogados, actividades, documentos, etc.
                8.	Pruebas con usuarios: probaría el sistema con algunos abogados y asistentes del bufete para validar que la información se ve clara y que el flujo de trabajo es entendible.
                9.	Capacitación y despliegue: capacitaría al personal y migraría progresivamente la información desde las hojas de cálculo al nuevo sistema.
                10.	Mantenimiento y mejoras: escucharía comentarios, corregiría errores y, con el tiempo, agregaría más funciones como reportes, estadísticas o integración con otros sistemas.
            </p>

            <h2>3. ¿Qué estructura tendría la base de datos?</h2>
            <p>
                Mi base de datos se llama FranciscoLata y está organizada en varias tablas principales, todas con el prefijo FL_:
                FL_Clientes: guarda los datos básicos de los clientes del bufete.
                IdCliente, NombreCompleto, Telefono, Correo, Direccion.
                FL_Abogados: registra a los abogados del bufete.
                IdAbogado, NombreCompleto, Especialidad, Correo, Telefono, Activo.
                FL_Casos: es la tabla central del sistema, donde se registran los expedientes de cada caso.
                IdCaso, CodigoCaso, IdCliente, IdAbogadoAsignado, Titulo, Descripcion, FechaInicio, FechaVencimiento, Estado, Prioridad.
                FL_ActividadesCaso: almacena las reuniones, audiencias y otros hitos asociados a cada caso.
                IdActividad, IdCaso, TipoActividad, FechaHoraInicio, FechaHoraFin, Descripcion, RequiereRecordatorio, Estado.
                FL_DocumentosCaso: sirve para asociar documentos a los casos (por ejemplo: demandas, escritos, evidencias).
                IdDocumento, IdCaso, NombreArchivo, TipoDocumento, RutaArchivo, FechaRegistro, Notas.
                De esta forma, cada caso se relaciona con un cliente, con un abogado responsable, con varias actividades y con varios documentos.
            </p>

            <h2>4. ¿Por qué elegí esta estructura y qué ventajas/desventajas tiene?</h2>
            <p>
                Elegí esta estructura porque está normalizada y separa claramente los conceptos principales del negocio: clientes, abogados, casos, actividades y documentos. Cada tabla tiene una responsabilidad clara y se relaciona con las demás mediante claves foráneas.
                Ventajas de este diseño:
                Evita la duplicación de datos. Por ejemplo, la información de un cliente se guarda una sola vez en FL_Clientes y luego se relaciona con muchos casos.
                Es flexible y escalable. Si el bufete quiere agregar nuevas funcionalidades (por ejemplo, tipos de actividades o categorías de documentos), puedo agregar nuevas tablas o columnas sin reestructurar todo el sistema.
                Facilita las consultas y reportes. Desde FL_Casos puedo unirme con FL_Clientes, FL_Abogados, FL_ActividadesCaso y FL_DocumentosCaso para obtener información consolidada de cada caso.
                Desventajas de este diseño:
                Al estar dividido en varias tablas, algunas consultas requieren varios JOINs, lo que puede hacer las consultas un poco más complejas de escribir.
                Para alguien que no está acostumbrado a bases de datos relacionales, la cantidad de tablas puede parecer alta y al inicio puede costar entender todas las relaciones.
                Aun así, considero que las ventajas superan las desventajas, porque este diseño da orden, consistencia y facilita el crecimiento futuro del sistema.
            </p>

            <h2>5. ¿Qué interfaz gráfica utilizaría?</h2>
            <p>
                Yo utilizaría una interfaz web sencilla pero clara, desarrollada con ASP.NET Web Forms. Tendría un menú principal con opciones como:
                Inicio
                Casos
                Clientes
                Abogados
                Agenda / Actividades
                Documentos
                En la pantalla de Casos mostraría una tabla con el listado de casos, incluyendo columnas como: código del caso, título, cliente, abogado, fecha de inicio, fecha de vencimiento y estado. Desde ahí se podría entrar a un formulario para ver el detalle del caso y sus actividades.
                Visualmente, usaría un diseño limpio, con colores sobrios (por ejemplo, azul oscuro y gris) que transmitan seriedad profesional. El objetivo de la interfaz no sería ser “bonita” solamente, sino que la información sea fácil de encontrar: filtros, tablas ordenables y botones claros para acciones como “Nuevo caso”, “Editar” y “Ver agenda”.
            </p>

            <hr />

            <h2>Casos registrados en la base de datos</h2>
            <asp:GridView ID="gvCasos" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="CodigoCaso" HeaderText="Código del caso" />
                    <asp:BoundField DataField="Titulo" HeaderText="Título" />
                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="NombreAbogado" HeaderText="Abogado asignado" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de inicio" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha de vencimiento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

        </div>
    </form>
</body>
</html>
