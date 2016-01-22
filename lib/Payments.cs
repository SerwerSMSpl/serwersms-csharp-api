/*
 * Created by SharpDevelop.
 * User: Przemek
 * Date: 18.01.2016
 * Time: 14:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using serwersms;
using System.Web;
using System.IO;
using System.Linq;

namespace serwersms.lib
{
	
	public class Payments
	{
		private SerwerSMS obj = null;
		
		public Payments( SerwerSMS obj )
		{
			this.obj = obj;
		}
		
		/**
		 * List of payments
		 * 
		 * @return array
		 *      @option array "items"
		 *          @option int "id"
		 *          @option string "number"
		 *          @option string "state" paid|not_paid
		 *          @option float "paid"
		 *          @option float "total"
		 *          @option string "payment_to"
		 *          @option string "url"
		 */
		public Object index() {
	        	
			var data = new Dictionary<String, String>();
	        return this.obj.call("payments/index",data);
	    
	    }
		/**
		 * View single payment
		 * 
		 * @param int $id
		 * @return array
		 *      @option int "id"
		 *      @option string "number"
		 *      @option string "state" paid|not_paid
		 *      @option float "paid"
		 *      @option float "total"
		 *      @option string "payment_to"
		 *      @option string "url"
		 */
		public Object view( String id) {
        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);

	        return this.obj.call("payments/view",data);
	    
	    }
		/**
		 * Download invoice as PDF
		 * 
		 * @param int $id
		 * @return resource
		 */
		public Stream invoice( String id) {
        	
			var data = new Dictionary<String, String>();
			data.Add("id",id);

	        return this.obj.callStream("payments/invoice",data);
	    
	    }
		
		public void saveFile( Stream stream, String path) {
        	
			var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		    stream.CopyTo(fileStream);
		    fileStream.Dispose();
	    
	    }
	}
	
}
