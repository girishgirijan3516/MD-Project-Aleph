package md5ded98775bad3f6602e0d09d02c5da7b7;


public class MP3Play
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("Aleph.MP3Play, Aleph", MP3Play.class, __md_methods);
	}


	public MP3Play ()
	{
		super ();
		if (getClass () == MP3Play.class)
			mono.android.TypeManager.Activate ("Aleph.MP3Play, Aleph", "", this, new java.lang.Object[] {  });
	}

	public MP3Play (md5ded98775bad3f6602e0d09d02c5da7b7.BookContentListen p0)
	{
		super ();
		if (getClass () == MP3Play.class)
			mono.android.TypeManager.Activate ("Aleph.MP3Play, Aleph", "Aleph.BookContentListen, Aleph", this, new java.lang.Object[] { p0 });
	}


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}