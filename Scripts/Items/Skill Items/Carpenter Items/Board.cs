using System;

namespace Server.Items
{
	[FlipableAttribute( 0x1BD7, 0x1BDA )]
	public class Board : Item, ICommodity
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get { return m_Resource; }
			set { m_Resource = value; InvalidateProperties(); }
		}

		int ICommodity.DescriptionNumber
		{
			get
			{
				if( m_Resource >= CraftResource.OakWood && m_Resource <= CraftResource.YewWood )
					return 1075052 + ((int)m_Resource - (int)CraftResource.OakWood);

				return LabelNumber;
			}
		}

		bool ICommodity.IsDeedable { get { return true; } }

		[Constructable]
		public Board()
			: this( 1 )
		{
		}

		[Constructable]
		public Board( int amount )
			: this( CraftResource.RegularWood, amount )
		{
		}

		public Board( Serial serial )
			: base( serial )
		{
		}

		[Constructable]
		public Board( CraftResource resource )
			: this( resource, 1 )
		{
		}

		[Constructable]
		public Board( CraftResource resource, int amount )
			: base( 0x1BD7 )
		{
			Stackable = true;
			Amount = amount;

			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if( !CraftResources.IsStandard( m_Resource ) )
			{
				int num = CraftResources.GetLocalizationNumber( m_Resource );

				if( num > 0 )
					list.Add( num );
				else
					list.Add( CraftResources.GetName( m_Resource ) );
			}
		}



		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)3 );

			writer.Write( (int)m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch( version )
			{
				case 3:
				case 2:
					{
						m_Resource = (CraftResource)reader.ReadInt();
						break;
					}
			}

			if( (version == 0 && Weight == 0.1) || (version <= 2 && Weight == 2) )
				Weight = -1;

			if( version <= 1 )
				m_Resource = CraftResource.RegularWood;
		}
	}

	public class OakBoard : Board
	{
		[Constructable]
		public OakBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public OakBoard( int amount )
			: base( CraftResource.OakWood, amount )
		{
		}

		public OakBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class AshBoard : Board
	{
		[Constructable]
		public AshBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public AshBoard( int amount )
			: base( CraftResource.AshWood, amount )
		{
		}

		public AshBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class YewBoard : Board
	{
		[Constructable]
		public YewBoard()
			: this( 1 )
		{
		}

		[Constructable]
		public YewBoard( int amount )
			: base( CraftResource.YewWood, amount )
		{
		}

		public YewBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}