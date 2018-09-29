using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp
{
    class structdata
    {
        public struct booking_details
        {
            public string name, phonenumber, hotel, room_type, booking_source, book_date, checkout_date, book_time, checkout_time, period, advance_paid, invoice, roomnumber, status;


        }
        public struct book_avail
        {
            public string name, phonenumber, hotel, room_type, amount, book_date, checkout_date, book_time, checkout_time, advance_paid, roomnumber, status, available,count;
        }
        public struct basic_info
        {
            public string cc,name, address, district, state, country, pincode, phonenumber, mail, idproof, id_proof_number, foreigner, foreigner_details,cform_fill, marital_status, dob, anniversary_date, visit_count;


        }
        public struct kot_table
        {
            public string room_no, date, bill_no, nc_kot, amount, kot_type, number, items, session, steward;
        }
        public struct check_in_struct
        {
            public string kot_amount, check_out, phonenumber, checkin_date, checkin_time, checkout_date, checkout_time, referral, hotel_name, room_type, plan, no_of_persons, room_no, advance_paid, room_amt, post_charges, discount, transaction, nc_kot_count, Invoice_number,room_group,advance_used,total_amt,kot_paid,post_paid,room_paid;
        }
        public struct check
        {
            public basic_info customer;
            public bool available;
        }
        public struct check_in_check
        {
            public check_in_struct customer;
            public bool available;
        }

        public struct room_update
        {
            public String room_no, room_type, status, s_name, checkin_date, checkin_time, checkout_date, checkout_time, phonenumber, remark;
        }
        public struct checkout_update
        {
            public string phonenumber, room_no, checkoutdate, checkouttime, room_amt, discount, transaction_detail, total, checkout, remark, post_charge;
        }
        public struct user1
        {
            public string name, job, username, password, remark, fd_pre, fb_pre, hk_pre, store_pre, report_pre, add_u_pre;
        }
        public struct user_avail
        {
            public string name, job, username, password, remark, fd_pre, fb_pre, hk_pre, store_pre, report_pre, add_u_pre, available;
        }
        public struct night_audit1
        {
            public string room_no, book, book_rev, adv_rev, kot_rev, bill_no, nc_kot;
            public bool receive;
        }

    }
}
