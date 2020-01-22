
# BJT-Biasing [DC]

This program is calculating 7 BJT Biasing.

* [Code Toturial](https://github.com/MMovasaghi/BJT-Biasing#Code-Toturial)
* [Circuits](https://github.com/MMovasaghi/BJT-Biasing#circuits)

## Code Toturial

Class **DC_Bio** is the main class that calculation is done there.

### Class Properties
* `Beta` : The **β** of the Transistor.
* `Circuit_Number` : The number of cirtuit that has been selected.(distinguish by Fig. number.)
* `Je` : The **Emitter Junction** for the Transistor.
* `Ie` : The current of the Emitter.
* `Ib` : The current of the Base.
* `Ic` : The current of the Collector.
* `R_E` : The Resistor of the Emitter.
* `R_B` : The Resistor of the Base.
* `R_C` : The Resistor of the Collector.
* `V_EE` : Voltage generator of the Emitter.
* `V_BB` : Voltage generator of the Base.
* `V_CC` : Voltage generator of the Collector.
* `V_CE` : The **Collector-Emitter Voltage**.
* `V_BE` : The Base-Emitter Voltage that it's default value is `0.7`.
> If pass the `0` value to this property it set the default value.[It must be send at least one value to it.]
* `V_Sat` : The Collector-Emitter Saturation Voltage that it's default value is `0.2`.
> If pass the `0` value to this property it set the default value.[It must be send at least one value to it.]

### Class Methods
* **Cunstructor**
	- **Arguments** : 
		- bool  jE, 
		- int  circuit_number, 
		- decimal  beta, 
		- decimal  vsat  =  0 // default value is 0
		
	- **Description** : 
		- It is initial the value of `Je` , `Circuit_Number` , `Beta` , `V_Sat`.
		
	- **Return Type** : `none` 
	
* **DC_Initial**
	- **Arguments** : 
		- decimal  rc  =  0,
		- decimal  rb  =  0, 
		- decimal  vbb  =  0, 
		- decimal  vcc  =  0, 
		- decimal  re  =  0, 
		- decimal  rb1  =  0, 
		- decimal  rb2  =  0,
		- decimal  vee  =  0
		> All arguments have default value 0.
		
	- **Description** : 
		- It is initial the value of all it's equal props.
		
	- **Return Type** : `void` 

* **CalCulate_VCE**
	- **Arguments** : `none` 
		
	- **Description** : 
		- It is calculate the amount of the `V_CE`.
		
	- **Return Type** : `decimal` the result of `V_CE` value.

* **Cal_Ic**
	- **Arguments** : `none` 
		
	- **Description** : 
		- It is calculate the amount of the `Ic` by `Ib`.
		
	- **Return Type** : `decimal` the result of `Ic` value.

* **Cal_Ie**
	- **Arguments** : `none` 
		
	- **Description** : 
		- It is calculate the amount of the `Ie`.
		
	- **Return Type** : `decimal` the result of `Ie` value.
	
* **Cal_Ib**
	- **Arguments** : `none` 
		
	- **Description** : 
		- It is calculate the amount of the `Ib` that distinguished by `Circuit_Number`.
		
	- **Return Type** : `decimal` the result of `Ib` value.

* **Cal_Vce**
	- **Arguments** : `none` 
		
	- **Description** : 
		- After calculating `Ic` and `Ib` that has been called in `CalCulate_VCE` method , the `CalCulate_VCE` method call the `Cal_Vce` to calculate the `V_CE`.
		
	- **Return Type** : `decimal` the result of `V_CE` value.
	
* **IsActive**
	- **Arguments** : 
		- decimal Vce
		
	- **Description** : 
		- It is find the stated of the Transistor.
		
	- **Return Type** : `int` , it is return `2` if transistor is `Active` , return `1` if transistor is `Saturated` , return `0` if transistor is `disable`.

* **IsActive_Message**
	- **Arguments** : 
		- decimal Vce
		
	- **Description** : 
		- It is find the stated of the Transistor by calling `IsActive` method.
		
	- **Return Type** : `string`, it is return the message to show the state of the transistor.
	
------------------------------------------------------------------------------------------------------------------------------------

## Circuits

For all the circuits we must get `β` , `V_BE` , `V_Sat` .

By default they are assign such this value:

` V_Sat = 0.2 `(`V_Sat` is `V_CE` in the **Saturation** mode)

` V_BE = 0.7 `

### Circuit 1

<p align="left">
  <img src="https://github.com/MMovasaghi/BJT-Biasing/blob/master/Figures/Figure1.1.png" 
       width="20%" title="hover text">
</p>
Fig. 1.1

For this circuit we should get `R_B` , `R_C` , `V_CC` , `V_BB` form the user.

----------------------------------------------------------------------------------------------------

### Circuit 2

<p align="left">
  <img src="https://github.com/MMovasaghi/BJT-Biasing/blob/master/Figures/Figure1.2.png" 
       width="20%" title="hover text">
</p>
Fig. 1.2

For this circuit we should get `R_B` , `R_C` , `R_E` , `V_CC` , `V_BB` form the user.

----------------------------------------------------------------------------------------------------

### Circuit 3

<p align="left">
  <img src="https://github.com/MMovasaghi/BJT-Biasing/blob/master/Figures/Figure1.3.png" 
       width="20%" title="hover text">
</p>
Fig. 1.3

For this circuit we should get `R_B` , `R_C` , `V_CC` form the user.

----------------------------------------------------------------------------------------------------

### Circuit 4

<p align="left">
  <img src="https://github.com/MMovasaghi/BJT-Biasing/blob/master/Figures/Figure1.4.png" 
       width="20%" title="hover text">
</p>
Fig. 1.4

For this circuit we should get `R_B` , `R_C` , `R_E` , `V_CC` form the user.

----------------------------------------------------------------------------------------------------

### Circuit 5

<p align="left">
  <img src="https://github.com/MMovasaghi/BJT-Biasing/blob/master/Figures/Figure1.5.png" 
       width="40%" title="hover text">
</p>
Fig. 1.5

For this circuit we should get `R_B1` , `R_B2` , `R_C` , `R_E` , `V_CC` form the user.

----------------------------------------------------------------------------------------------------

### Circuit 6

<p align="left">
  <img src="https://github.com/MMovasaghi/BJT-Biasing/blob/master/Figures/Figure1.6.png" 
       width="20%" title="hover text">
</p>
Fig. 1.6

For this circuit we should get `R_B` , `R_C` , `R_E` , `V_CC` form the user.

----------------------------------------------------------------------------------------------------
### Circuit 7

<p align="left">
  <img src="https://github.com/MMovasaghi/BJT-Biasing/blob/master/Figures/Figure1.7.png" 
       width="20%" title="hover text">
</p>
Fig. 1.7

For this circuit we should get `R_B` , `R_C` , `R_E` , `V_CC` form the user.

----------------------------------------------------------------------------------------------------
