<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
  xmlns:user="urn:my-scripts">
	<xsl:output method="text" indent="yes"/>

	<xsl:template match="/">
		<xsl:for-each select="Schedule/DayOfWeek">
			<xsl:text>День недели: </xsl:text>
			<xsl:value-of select="@name" />
<xsl:text>
</xsl:text>
			<xsl:for-each select="Group">
				<xsl:text>Группа: </xsl:text>
				<xsl:value-of select="@name" />
<xsl:text>
</xsl:text>
				<xsl:for-each select="Lesson">
					
	<xsl:text>
	</xsl:text>
					<xsl:text>Предмет: </xsl:text>
					<xsl:value-of select="Name"/>
	<xsl:text>
	</xsl:text>
					<xsl:text>Аудитория: </xsl:text>
					<xsl:value-of select="Audience"/>
	<xsl:text>
	</xsl:text>
					<xsl:text>Преподаватель: </xsl:text>
					<xsl:value-of select="Teacher"/>

	<xsl:text>
	</xsl:text>
					<xsl:text>тип занятия: </xsl:text>
					<xsl:value-of select="Type"/>

	<xsl:text>
	</xsl:text>
					<xsl:text>Время начала: </xsl:text>
					<xsl:value-of select="Start"/>

	<xsl:text>
	</xsl:text>
					<xsl:text>Время окончания: </xsl:text>
					<xsl:value-of select="End"/>
<xsl:text>
</xsl:text>
				</xsl:for-each>
			</xsl:for-each>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
