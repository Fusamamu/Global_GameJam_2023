using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class MaterialController : MonoBehaviour
    {
	    public bool UseMaterialPropBlock;
	    
	    [SerializeField] private Renderer Renderer;
	    
	    [SerializeField] private Color TopColor;
	    [SerializeField] private Color FrontColor;
	    [SerializeField] private Color SideColor;

	    [Header("Color Scheme Version 1")]
	    [SerializeField] private Color TC1;
	    [SerializeField] private Color FC1;
	    [SerializeField] private Color SC1;

	    private MaterialPropertyBlock materialPropertyBlock;
	    
	    private static readonly int topColor   = Shader.PropertyToID("_TopColor");
	    private static readonly int frontColor = Shader.PropertyToID("_FrontColor");
	    private static readonly int sideColor  = Shader.PropertyToID("_SideColor");

#if UNITY_EDITOR
        private void OnValidate()
        {
	        if (!Renderer)
		        Renderer = GetComponent<Renderer>();
	       
	        if(UseMaterialPropBlock)
				UpdateMaterial();
        }
#endif

	    public void SelectColorSchemeVersion(int _version)
	    {
		    if(!UseMaterialPropBlock) return;
		    
		    if (_version == 1)
		    {
			    TopColor   = TC1;
			    FrontColor = FC1;
			    SideColor  = SC1;
		    }
		    
		    UpdateMaterial();
	    }

	    public void UpdateMaterial()
	    {
		    materialPropertyBlock ??= new MaterialPropertyBlock();

		    Renderer.GetPropertyBlock(materialPropertyBlock);
		    
		    materialPropertyBlock.SetColor(topColor, TopColor);
		    materialPropertyBlock.SetColor(frontColor, FrontColor);
		    materialPropertyBlock.SetColor(sideColor, SideColor);
		    
		    Renderer.SetPropertyBlock(materialPropertyBlock);
	    }
    }
}
