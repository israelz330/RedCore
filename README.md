# Eaton Durant 58811-400 LED serial data converter to a Red Lion Large LED Display

Here's some background: there's an Industrial PC that uses legacy software to get serial data from an Eaton Durant Totalizer device. This Durant device is obsolete, so we need to replace it with a new, modern totalizer. We can't update the software that reads the serial data, so we added a Raspberry Pi as an interpreter and converter. The Raspberry Pi reads the new Red Lion serial data and converts it to the expected serial data, as if it were coming from the deprecated Durant device.

Obsolete Eator Durant Totalizer
<img src="/images/EATON.jpg">

Red Lion LED Display
<img src="/images/REDLION.jpg">
