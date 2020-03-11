package classes;

import org.openqa.selenium.By;

import com.prolifics.ProlificsSeleniumAPI;
public class Home {
	
	ProlificsSeleniumAPI oPSelFW;
	
	//Locators	
	 
	//public String INDUSTRIES_LINK = "linkText=Industries";
	public String INDUSTRIES_LINK = "xpath=(//a[contains(text(),'Industries')])[2]";
	public String TV_ENTERTAINMENT="//span[contains(text(),'TV & Entertainment')]";
	//Constructor
	public Home(ProlificsSeleniumAPI oPSelFW)
	{
		this.oPSelFW = oPSelFW;
	}
	
	/**
	 * @Purpose Click on About link
	 * @Developed By Anustup.
	 * @param 
	 * @param About-Link
	 * @throws InterruptedException 
	 * @throws Exception
	 */
	
	
	public void click_IndustriesHomePage() throws InterruptedException
	{
		Thread.sleep(5000);
		//oPSelFW.driver.findElement(By.linkText("Industries")).click();
		oPSelFW.prolifics("waitForElementPresent",INDUSTRIES_LINK,"60","Industries Link");
		oPSelFW.prolifics("click",INDUSTRIES_LINK,"Industries Link");
		Thread.sleep(5000);
	}

	public void click_TvEntertainment() throws Exception {
		
		Thread.sleep(3000);
		oPSelFW.prolifics("waitForElementPresent",TV_ENTERTAINMENT,"60","Tv & Entertainmnet");
		oPSelFW.prolifics("click",TV_ENTERTAINMENT,"Tv & Entertainmnet");
		
	}
}
