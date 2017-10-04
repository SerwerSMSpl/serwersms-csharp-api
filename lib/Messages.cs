/*
 * Created by SharpDevelop.
 * User: Przemek
 * Date: 15.01.2016
 * Time: 15:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using serwersms;

namespace serwersms.lib
{

	public class Messages
	{
		private SerwerSMS obj = null;
		
		public Messages(SerwerSMS obj){
		
			this.obj = obj;
		}
		
		/**
		 * Sending messages
		 * 
		 * @param String phone
		 * @param String text Message
		 * @param String sender Sender name only for FULL SMS
		 * @param array params
		 *      @option String "details" Show details of messages
		 *      @option String "utf" Change encoding to UTF-8 (Only for FULL SMS)
		 *      @option String "flash"
		 *      @option String "speed" Priority canal only for FULL SMS
		 *      @option String "test" Test mode
		 *      @option String "vcard" vCard message
		 *      @option String "wap_push" WAP Push URL address
		 *      @option String "date" Set the date of sending
		 *      @option String "group_id" Sending to the group instead of a phone number
		 *      @option String "contact_id" Sending to phone from contacts
		 *      @option String "unique_id" Own identifiers of messages
		 * @return array
		 *      @option Boolean "success"
		 *      @option int "queued" Number of queued messages
		 *      @option int "unsent" Number of unsent messages
		 *      @option array "items"
		 *          @option String "id"
		 *          @option String "phone"
		 *          @option String "status" - queued|unsent
		 *          @option String "queued" Date of enqueued
		 *          @option int "parts" Number of parts a message
		 *          @option int "error_code"
		 *          @option String "error_message"
		 *          @option String "text"
		 */
		
		public Object sendSms( String phone, String text, String sender = null,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("phone",phone);
				arr.Add("text",text);
				arr.Add("sender",sender);
				data = arr;
				
			}else{
				
				data.Add("phone",phone);
				data.Add("text",text);
				data.Add("sender",sender);
				

			}
	        return this.obj.call("messages/send_sms",data);
	    
	    }
		/**
		 * Sending personalized messages
		 * 
		 * @param array messages
		 *      @option String "phone"
		 *      @option String "text"
		 * @param String sender Sender name only for FULL SMS
		 * @param array params
		 *      @option String "details" Show details of messages
		 *      @option String "utf" Change encoding to UTF-8 (only for FULL SMS)
		 *      @option String "flash"
		 *      @option String "speed" Priority canal only for FULL SMS
		 *      @option String "test" Test mode
		 *      @option String "date" Set the date of sending
		 *      @option String "group_id" Sending to the group instead of a phone number
		 *      @option String "text" Message if is set group_id
		 *      @option String "uniqe_id" Own identifiers of messages
		 *      @option String "voice" Send VMS
		 * @return array
		 *      @option Boolean "success"
		 *      @option int "queued" Number of queued messages
		 *      @option int "unsent" Number of unsent messages
		 *      @option array "items"
		 *          @option String "id"
		 *          @option String "phone"
		 *          @option String "status" - queued|unsent
		 *          @option String "queued" Date of enqueued
		 *          @option int "parts" Number of parts a message
		 *          @option int "error_code"
		 *          @option String "error_message"
		 *          @option String "text"
		 */
		public Object sendPersonalized( List <Dictionary<String, String>> messages,String sender = null,Dictionary<String, String> data = null) {
        	
			var smessages = "[";
			int index=0;
			int count = messages.Count;
			foreach(Dictionary<String, String> message in messages)
			{
				index++;
				smessages += message["phone"]+":"+message["text"]+"]";
				if(count != index){
					smessages += "|[";
				}
				
			}

			
			smessages = smessages.TrimEnd(']');

			if(smessages.Length == 1){
			
				smessages.Replace("[","");
				
			}
			Console.WriteLine(smessages.ToString());
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("messages",smessages);
				arr.Add("sender",sender);
				data = arr;
				
			}else{
				
				data.Add("messages",smessages);
				data.Add("sender",sender);
				

			}
	        return this.obj.call("messages/send_personalized",data);
	    
	    }
		/**
		 * Sending Voice message
		 * 
		 * @param String phone
		 * @param array params
		 *      @option String "text" If send of text to voice
		 *      @option String "file_id" ID from wav files
		 *      @option String "date" Set the date of sending
		 *      @option String "test" Test mode
		 *      @option String "group_id" Sending to the group instead of a phone number
		 *      @option String "contact_id" Sending to phone from contacts
		 * @return array
		 *      @option Boolean "success"
		 *      @option int "queued" Number of queued messages
		 *      @option int "unsent" Number of unsent messages
		 *      @option array "items"
		 *          @option String "id"
		 *          @option String "phone"
		 *          @option String "status" - queued|unsent
		 *          @option String "queued" Date of enqueued
		 *          @option int "parts" Number of parts a message
		 *          @option int "error_code"
		 *          @option String "error_message"
		 *          @option String "text"
		 */
		public Object sendVoice( String phone,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("phone",phone);
				data = arr;
				
			}else{
				
				data.Add("phone",phone);
				
			}
	        return this.obj.call("messages/send_voice",data);
	    
	    }
		/**
		 * Sending MMS
		 * 
		 * @param String phone
		 * @param String title Title of message (max 40 chars)
		 * @param array params
		 *      @option String "file_id"
		 *      @option String "file" File in base64 encoding
		 *      @option String "date" Set the date of sending
		 *      @option String "test" Test mode
		 *      @option String "group_id" Sending to the group instead of a phone number
		 * @return array
		 *      @option Boolean "success"
		 *      @option int "queued" Number of queued messages
		 *      @option int "unsent" Number of unsent messages
		 *      @option array "items"
		 *          @option String "id"
		 *          @option String "phone"
		 *          @option String "status" - queued|unsent
		 *          @option String "queued" Date of enqueued
		 *          @option int "parts" Number of parts a message
		 *          @option int "error_code"
		 *          @option String "error_message"
		 *          @option String "text"
		 */
		public Object sendMms( String phone,String title,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("phone",phone);
				arr.Add("title",title);
				data = arr;
				
			}else{
				
				data.Add("phone",phone);
				data.Add("title",title);
				
			}
	        return this.obj.call("messages/send_mms",data);
	    
	    }
		/**
		 * View single message
		 * 
		 * @param String id
		 * @param array params
		 *      @option String "unique_id"
		 *      @option String "show_contact" Show details of the recipient from the contacts
		 * @return array
		 *      @option String "id"
		 *      @option String "phone"
		 *      @option String "status"
		 *          - delivered: The message is sent and delivered
		 *          - undelivered: The message is sent but not delivered
		 *          - sent: The message is sent and waiting for report
		 *          - unsent: The message wasn't sent
		 *          - in_progress: The message is queued for sending 
		 *          - saved: The message was saved in schedule
		 *      @option String "queued" Date of enqueued
		 *      @option String "sent" Date of sending
		 *      @option String "delivered" Date of deliver
		 *      @option String "sender"
		 *      @option String "type" - eco|full|mms|voice
		 *      @option String "text"
		 *      @option String "reason"
		 *          - message_expired
		 *          - unsupported_number
		 *          - message_rejected
		 *          - missed_call
		 *          - wrong_number
		 *          - limit_exhausted
		 *          - lock_send
		 *          - wrong_message
		 *          - operator_error
		 *          - wrong_sender_name
		 *          - number_is_blacklisted
		 *          - sending_to_foreign_networks_is_locked
		 *          - no_permission_to_send_messages
		 *          - other_error
		 *      @option array "contact"
		 *          @option String "first_name"
		 *          @option String "last_name"
		 *          @option String "company"
		 *          @option String "phone"
		 *          @option String "email"
		 *          @option String "tax_id"
		 *          @option String "city"
		 *          @option String "address"
		 *          @option String "description"
		 */
		public Object view( String id,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("id",id);
				data = arr;
				
			}else{
				
				data.Add("id",id);
				
			}
	        return this.obj.call("messages/view",data);
	    
	    }
		/**
		 * Checking messages reports
		 * 
		 * @param array params
		 *      @option String|array "id" ID message
		 *      @option String|array "unique_id" ID message
		 *      @option String|array "phone"
		 *      @option String "date_from" The scope of the initial
		 *      @option String "date_to" The scope of the final
		 *      @option String "status" delivered|undelivered|pending|sent|unsent
		 *      @option String "type" eco|full|mms|voice
		 *      @option int "stat_id" Id package messages
		 *      @option Boolean "show_contact" Show details of the recipient from the contacts
		 *      @option int "page" The number of the displayed page
		 *      @option int "limit" Limit items are displayed on the single page
	     *      @option String "order" asc|desc
		 * @return array
		 *      @option array "paging"
		 *          @option int "page" The number of current page
		 *          @option int "count" The number of all pages
		 *      @option array items
		 *          @option String "id"
		 *          @option String "phone"
		 *          @option String "status"
		 *              - delivered: The message is sent and delivered
		 *              - undelivered: The message is sent but not delivered
		 *              - sent: The message is sent and waiting for report
		 *              - unsent: The message wasn't sent
		 *              - in_progress: The message is queued for sending 
		 *              - saved: The message was saved in the scheduler
		 *          @option String "queued" Date of enqueued
		 *          @option String "sent" Date of sending
		 *          @option String "delivered" Date of deliver
		 *          @option String "sender"
		 *          @option String "type" - eco|full|mms|voice
		 *          @option String "text"
		 *          @option String "reason"
		 *              - message_expired
		 *              - unsupported_number
		 *              - message_rejected
		 *              - missed_call
		 *              - wrong_number
		 *              - limit_exhausted
		 *              - lock_send
		 *              - wrong_message
		 *              - operator_error
		 *              - wrong_sender_name
		 *              - number_is_blacklisted
		 *              - sending_to_foreign_networks_is_locked
		 *              - no_permission_to_send_messages
		 *              - other_error
		 *          @option array "contact"
		 *              @option String "first_name"
		 *              @option String "last_name"
		 *              @option String "company"
		 *              @option String "phone"
		 *              @option String "email"
		 *              @option String "tax_id"
		 *              @option String "city"
		 *              @option String "address"
		 *              @option String "description"
		 */
		public Object reports( Dictionary<String, String> data ) {
        	
	        return this.obj.call("messages/reports",data);
	    
	    }
		/**
		 * Deleting message from the scheduler
		 * 
		 * @param String id
		 * @param String unique_id
		 * @return array
		 *      @option Boolean "success"
		 */
		public Object delete( String id,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				arr.Add("id",id);
				data = arr;
				
			}else{
				
				data.Add("id",id);
				
			}
	        return this.obj.call("messages/delete",data);
	    
	    }
		/**
		 * List of received messages
		 * 
		 * @param String type
		 *      - eco SMS ECO replies
		 *      - nd Incoming messages to ND number
		 *      - ndi Incoming messages to ND number
		 *      - mms Incoming MMS
		 * @param array params
		 *      @option String "ndi" Filtering by NDI
		 *      @option String "phone" Filtering by phone
		 *      @option String "date_from" The scope of the initial
		 *      @option String "date_to" The scope of the final
		 *      @option Boolean "read" Mark as read
		 *      @option int "page" The number of the displayed page
		 *      @option int "limit" Limit items are displayed on the single page
	     *      @option String "order" asc|desc
		 * @return array
		 *      @option array "paging"
		 *          @option int "page" The number of current page
		 *          @option int "count" The number of all pages
		 *      @option array "items"
		 *          @option int "id"
		 *          @option String "type" eco|nd|ndi|mms
		 *          @option String "phone"
		 *          @option String "recived" Date of received message
		 *          @option String "message_id" ID of outgoing message (only for ECO SMS)
		 *          @option Boolean "blacklist" Is the phone is blacklisted?
		 *          @option String "text" Message
		 *          @option String "to_number" Number of the recipient (for MMS)
		 *          @option String "title" Title of message (for MMS)
		 *          @option array "attachments" (for MMS)
		 *              @option int "id"
		 *              @option String "name"
		 *              @option String "content_type"
		 *              @option String "data" File
		 *          @option array "contact"
		 *              @option String "first_name"
		 *              @option String "last_name"
		 *              @option String "company"
		 *              @option String "phone"
		 *              @option String "email"
		 *              @option String "tax_id"
		 *              @option String "city"
		 *              @option String "address"
		 *              @option String "description"
		 */
		public Object recived( String type,Dictionary<String, String> data = null) {
        	
			if( data == null ){
				
				var arr = new Dictionary<String, String>();
				
				arr.Add("type",type);
				data = arr;
				
			}else{
				
				data.Add("type",type);
				
			}
	        return this.obj.call("messages/recived",data);
	    
	    }
		/**
		 * Sending a message to an ND/SC
		 * 
		 * @param String phone Sender phone number
		 * @param String text Message
		 * @return array
		 *      @option Boolean "success"
		 */
		public Object sendNd( String phone, String text) {
        	
			var data = new Dictionary<String, String>();
			data.Add("text",text);
			
	        return this.obj.call("messages/send_nd",data);
	    
	    }
		/**
		 * Sending a message to an NDI/SCI
		 * 
		 * @param String phone Sender phone number
		 * @param String text Message
		 * @param String ndi_number Recipient phone number
		 * @return array
		 *      @option Boolean "success"
		 */
		public Object sendNdi( String phone, String text, String ndi_number) {
        	
			var data = new Dictionary<String, String>();
			data.Add("text",text);
			data.Add("ndi_number",ndi_number);
			
	        return this.obj.call("messages/send_ndi",data);
	    
	    }
	}
}
