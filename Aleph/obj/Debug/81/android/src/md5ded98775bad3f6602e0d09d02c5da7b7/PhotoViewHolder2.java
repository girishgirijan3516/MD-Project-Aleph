package md5ded98775bad3f6602e0d09d02c5da7b7;


public class PhotoViewHolder2
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Aleph.PhotoViewHolder2, Aleph", PhotoViewHolder2.class, __md_methods);
	}


	public PhotoViewHolder2 (android.view.View p0)
	{
		super (p0);
		if (getClass () == PhotoViewHolder2.class)
			mono.android.TypeManager.Activate ("Aleph.PhotoViewHolder2, Aleph", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
