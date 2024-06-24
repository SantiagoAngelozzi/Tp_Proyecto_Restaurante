# Proyecto de Logística de Restaurante

## Descripción del Proyecto

Este proyecto consiste en la implementación de un sistema de logística para un restaurante, abarcando diversos aspectos de su operación diaria. El sistema está diseñado para gestionar eficientemente la administración de stock, el menú del restaurante, la contabilidad y el registro de consumos.

## Conceptos Técnicos

### Encapsulamiento
El principio de encapsulamiento se ha aplicado extensivamente para asegurar que los datos internos de las clases estén protegidos del acceso no autorizado. Esto se logra mediante el uso de modificadores de acceso y la implementación de métodos getter y setter para controlar el acceso a las propiedades de las clases.

### Herencia
La herencia se ha utilizado para crear una jerarquía de clases que permite la reutilización del código y la creación de relaciones lógicas entre las entidades del sistema. Por ejemplo, la clase Empleado es una clase base de la cual heredan clases específicas como Cocinero, Encargado, Mesero y DeliveryBoy.

### Sobrecarga de Constructores
La sobrecarga de constructores se ha empleado para proporcionar múltiples formas de instanciar objetos de las clases. Esto permite una mayor flexibilidad al crear instancias de las clases con diferentes conjuntos de parámetros, adecuándose a diversas necesidades del sistema.

### Clases Abstractas
Las clases abstractas, como Empleado, se han utilizado para definir una estructura común y comportamientos compartidos entre las subclases. Estas clases no pueden ser instanciadas directamente y sirven como plantilla para las clases derivadas, asegurando que todas implementen los métodos definidos en la clase abstracta.

### Excepciones
La gestión de excepciones es crucial para manejar errores y condiciones inesperadas que pueden ocurrir durante la ejecución del sistema. Se han implementado mecanismos de control de excepciones para asegurar que el sistema pueda manejar errores de manera elegante y mantener la integridad de los datos.

### Testing
El proyecto incluye un conjunto de pruebas unitarias para validar el correcto funcionamiento de las diferentes partes del sistema. Las pruebas se han implementado utilizando el framework MSTest, y abarcan diversos escenarios para asegurar que el sistema se comporte de manera esperada bajo diferentes condiciones.

## Flujo de Interacción

### Administración de Stock
El sistema permite la gestión detallada del inventario del restaurante, incluyendo la compra de productos y bebidas de proveedores, el seguimiento de la cantidad de cada producto y la actualización del stock en tiempo real.

### Administración del Menú
La administración del menú incluye la creación, modificación y eliminación de platos. Cada plato puede estar compuesto por varios ingredientes, y el sistema asegura que los ingredientes estén disponibles en el stock antes de permitir la preparación del plato.

### Administración Contable
La administración contable incluye el cálculo de sueldos de los empleados, la gestión de los ingresos y egresos del restaurante, y la generación de reportes financieros para mantener una visión clara del estado económico del negocio.

### Registro de Consumos
El registro de consumos abarca la captura y seguimiento de todos los pedidos realizados en el restaurante, ya sea en mesa o mediante delivery. Esto incluye el registro de los platos y bebidas consumidos, así como el cálculo de los ingresos generados por cada pedido.

## Conclusión

Este sistema de logística para restaurante proporciona una solución completa y eficiente para la gestión diaria del negocio, incorporando conceptos avanzados de programación orientada a objetos y asegurando una operación fluida y controlada del restaurante. El uso de técnicas como encapsulamiento, herencia, sobrecarga de constructores, clases abstractas y excepciones, combinado con un riguroso enfoque en testing, garantiza la robustez y fiabilidad del sistema.
