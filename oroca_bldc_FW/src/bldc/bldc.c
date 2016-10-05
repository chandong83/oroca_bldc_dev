/*
	Copyright 2012-2015 Benjamin Vedder	benjamin@vedder.se

	This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
    */
/*
	OROCA BLDC PROJECT.
*/
#include "ch.h"
#include "hal.h"
#include "stm32f4xx_conf.h"

#include "hw.h"
#include "bldc.h"
#include "Mcpwm.h"
#include "uart3_print.h"
//#include "../../mavlink/oroca_bldc/mavlink.h"

#include <math.h>
#include <string.h>
#include <stdarg.h>
#include <stdio.h>



/*
 * Timers used:
 * TIM7: servo
 * TIM1: mcpwm
 * TIM2: mcpwm
 * TIM12: mcpwm
 * TIM8: mcpwm
 * TIM3: servo_dec/Encoder (HW_R2)
 * TIM4: WS2811/WS2812 LEDs/Encoder (other HW)
 *
 * DMA/stream	Device		Function
 * 1, 2			I2C1		Nunchuk, temp on rev 4.5
 * 1, 7			I2C1		Nunchuk, temp on rev 4.5
 * 1, 1			UART3		HW_R2
 * 1, 3			UART3		HW_R2
 * 2, 2			UART6		Other HW
 * 2, 7			UART6		Other HW
 * 2, 4			ADC			mcpwm
 * 1, 0			TIM4		WS2811/WS2812 LEDs CH1 (Ch 1)
 * 1, 3			TIM4		WS2811/WS2812 LEDs CH2 (Ch 2)
 *
 */

static THD_WORKING_AREA(periodic_thread_wa, 1024);
static THD_WORKING_AREA(uart_thread_wa, 128);

static msg_t periodic_thread(void *arg) {
	(void)arg;

	chRegSetThreadName("Main periodic");

	Uart3_printf(&SD3, (uint8_t *)"periodic_thread\r\n");

	for(;;)
	{
		LED_GREEN_ON();
		chThdSleepMilliseconds(500);
		LED_GREEN_OFF();
		chThdSleepMilliseconds(500);
	}

	return 0;
}



int bldc_init(void)
{
	halInit();
	chSysInit();

	chThdSleepMilliseconds(1000);

	hw_init_gpio();

	Uart3_print_init();
	Uart3_printf(&SD3, (uint8_t *)"oroca_bldc\r\n");

	spi_dac_hw_init();
	spi_dac_write_A( 100) ;

	mcpwm_init();

	return 0;
}


static msg_t uart_process_thread(void *arg) {
	(void)arg;

	chRegSetThreadName("uart rx process");

	Uart3_printf(&SD3, (uint8_t *)"uart_process_thread\r\n");

	//process_tp = chThdSelf();

	for(;;)
	{
		//Uart3_printf(&SD3,  "%f,%f\r\n",ParkParm.qIa,ParkParm.qIb);
		//Uart3_printf(&SD3,  "%d  ,  %d,   %d\r\n",ParkParm*100.qAngle,ADC_Value[ADC_IND_CURR1],ADC_Value[ADC_IND_CURR2]);

		Uart3_printf(&SD3,  "%f   ",ParkParm.qAngle);
		//Uart3_printf(&SD3,  "%u  ",ADC_Value[ADC_IND_CURR1]);
		//Uart3_printf(&SD3,  "%u \r\n ",ADC_Value[ADC_IND_CURR2]);

		Uart3_printf(&SD3,  "%f   ",ParkParm.qIalpha);
		Uart3_printf(&SD3,  "%f   ",ParkParm.qIbeta);


		Uart3_printf(&SD3,  "%f   ",ParkParm.qId);
		Uart3_printf(&SD3,  "%f   \r\n ",ParkParm.qIq);
		chThdSleepMilliseconds(1);/*Wait for an arbitrary time*/

	}


	return 0;
}


float qVelRef = 0.01f;
float dbg_fTheta;
float dbg_fMea;
uint16_t dbg_AccumTheta;

int bldc_start(void)
{
	//-- 스레드 생성
	chThdCreateStatic(periodic_thread_wa, sizeof(periodic_thread_wa), NORMALPRIO, periodic_thread, NULL);
	chThdCreateStatic(uart_thread_wa, sizeof(uart_thread_wa), NORMALPRIO, uart_process_thread, NULL);

	Uart3_printf(&SD3, (uint8_t *)"bldc_start\r\n");


	for(;;)
	{

		//Ch = usb_uart_getch();

		/*
		if( Ch == 'q' )
		{
			Ch = 0;
			qVelRef += 0.01;
			//debug_print_usb("Enter q : %f\r\n", qVelRef);

		}
		if( Ch == 'a' )
		{
			Ch = 0;
			qVelRef -= 0.01;
			//debug_print_usb("Enter a : %f\r\n", qVelRef);
		}
		*/

	}
}

